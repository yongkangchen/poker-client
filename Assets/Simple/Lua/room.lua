--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local Destroy = UnityEngine.Object.Destroy
local show_hint = require "hint"
local server = require "lib.server"
local msg = require "data.msg"
local show_dismiss = require "dismiss"
local show_apply = require "apply"
local show_dialog = require "dialog"
local game_cfg = require "game_cfg"
local game = require "game"

local function get_room_players(role_tbl)
    local tbl = {}
    for role_id, role in pairs(role_tbl) do
        local role_data = role.data
        role_data.id = role_id
        tbl[role_data.idx or 1] = role_data
    end
    return tbl
end

local function init_visit_list(visit_list)
    UI.Active(visit_list, true)

    local window_trans = visit_list:Find("window")
    UI.OnClick(visit_list, "btn", function()
        UI.Active(window_trans, true)
    end)

    UI.OnClick(window_trans, "close", function()
        UI.Active(window_trans, false)
    end)

    local trans_grid = window_trans:Find("scorllview/grid")
    local grid = trans_grid:GetComponent(UIGrid)
    local trans_card = trans_grid:Find("card")

    local visitor_tbl = {}
    local label_num = visit_list:Find("num"):GetComponent(UILabel)
    return function(id, name, is_add)
        if is_add then
            if visitor_tbl[id] then
                return
            end
            local card = UnityEngine.Object.Instantiate(trans_card).transform
            card:SetParent(trans_grid, false)

            local label_name = card:Find("name"):GetComponent(UILabel)
            label_name.text = UI.LimitName(name)

            local label_id = card:Find("id"):GetComponent(UILabel)
            label_id.text = id

            local visitor_pic = card:Find("icon/pic")
            UI.RoleHead(visitor_pic, id)

            UI.Active(card, true)
            visitor_tbl[id] = card
        elseif visitor_tbl[id] then
            Destroy(visitor_tbl[id].gameObject)--NOTE  或者对象池
            visitor_tbl[id] = nil
        end

        if label_num then
            label_num.text = tostring(table.length(visitor_tbl))
        end
        grid.repositionNow = true
    end, function(v)
        UI.Active(visit_list, v)
    end
end

return function(init_game, player_data, on_over)
    local on_close
    local room_data = player_data.room_data
    local player_id = player_data.id

    local role_tbl

    local transform = UI.InitPrefab("room")
    local is_reconnect = false
    local function close(is_over)
        if not on_over then
            return
        end

        local do_on_over = on_over
        on_over = nil

        transform:GetComponent(UIPanel).depth = -1
        Destroy(transform.gameObject, 0.06)

        if is_reconnect == false and player_data.room_data then
            if type(is_over) ~= "boolean" then
                is_over = player_data.room_data.round == player_data.room_data.max_round
            end
            if not is_over then
                player_data.room_data.round = player_data.room_data.round + 1
            else
                player_data.room_data = nil
            end
        end

        do_on_over()

        if on_close then
            local ok, err = pcall(on_close)
            if not ok then
                LERR("room on_close err: %s", err)
            end
        end
    end

    local function do_quit()
        -- LERR("room_data: %s", table.dump(room_data))
        if room_data.is_visit then
            server.room_out()
            return
        end

        if room_data.start_count == 0 then
            local is_host = room_data.host_id == player_id and not room_data.group_id
            show_dismiss(transform, not is_host, function()
                if is_host then
                    server.dismiss()
                else
                    server.room_out()
                end
            end)
        else
            show_dismiss(transform, false, function()
                server.apply()
            end)
        end
    end

    local function hide_waiting()
        UI.Active(transform:Find("waiting"), false)
        local blink = transform:Find("desk/blink")
        if blink then
            UI.Active(blink, true)
        end
    end

    UI.OnClick(transform, "buttons/quit", do_quit)
    UI.OnClick(transform, "buttons/setting", function()
        show_dialog("确认重新加载游戏？", function()
            UnityEngine.SceneManagement.SceneManager.LoadScene(0)
        end, function() end)
    end)

    UI.Active(transform:Find("buttons/voice"), false)
    UI.Active(transform:Find("buttons/chat"), false)

    local prepare = UI.GetComponent(transform, "waiting/prepare", UIToggle)

    if not player_data.is_playback then
        EventDelegate.Add(prepare.onChange, function()
            server.ready(prepare.value)
        end)

        server.renter()

        if room_data.round ~= 1 then
            server.ready(true)
        end
    end

    if room_data.round ~= 1 then
        UI.Active(transform:Find("waiting"), false)
    end

    local watch_game
    if room_data.can_visit_enter then 
        watch_game = UI.InitPrefab("watch_game", transform)
    end
    
    local startgame
    if room_data.auto_start_type == -1 and watch_game then
        startgame = UI.InitPrefab("startgame", watch_game)
        
        local start_pos = watch_game:Find("start_pos")
        if start_pos then
            startgame.position = start_pos.position
        end
        UI.Active(startgame:Find("mask"), true)
    else
        startgame = UI.Child(transform, "waiting/startgame")
        if not startgame then
            startgame = UI.InitPrefab("startgame", transform:Find("waiting"))
        end
        UI.Active(startgame, false)
    end
    
    UI.OnClick(startgame, nil, function()
        server.start_game()
    end)
    
    local function player_can_start()
        if room_data.auto_start_type then
            if room_data.auto_start_type ~= -1 then
                return
            end

            if player_id ~= room_data.host_id then
                return
            end
        else
            local can_start = false
            for _, role in pairs(role_tbl) do
                if role.data.idx == 1 and role.data.id == player_id then
                    can_start = true
                end
            end
            
            if not can_start then
                return
            end
        end
        return true
    end
    
    local function room_is_full(offset)
        local count = table.length(role_tbl or {}) + offset
        if count >= room_data.player_size or (room_data.max_player_size and count >= room_data.max_player_size) then
            return true
        end
    end
    
    local invite = transform:Find("waiting/invite")
    local function invite_center()
        local pos = invite.localPosition
        pos.x = 0
        invite.localPosition = pos
    end
    
    local show_sit_down
    local show_visitor_info
    local show_watch_btn
    if watch_game then
        UI.OnClick(watch_game, "bg/quit", do_quit)
        UI.Active(transform:Find("waiting/prepare"), false)
        UI.Active(transform:Find("waiting/cancel"), false)

        if room_data.is_visit then
            local sit_down = watch_game:Find("sit_down")
            UI.Active(watch_game:Find("bg"), true)
            UI.Active(invite, false)
            
            if room_data.auto_start_type == -1 then
                local sitdown_pos = watch_game:Find("sitdown_pos")
                if sitdown_pos then
                    sit_down.position = sitdown_pos.position
                end
            end
            
            show_sit_down = function()
                local offset = -1
                if role_tbl and not role_tbl[player_id] then
                    offset = 0
                end
                local active = room_data.is_visit and not room_is_full(offset)
                UI.Active(sit_down, active)

                if not active then
                    invite_center()
                end

                if room_data.start_count > 0 then
                    sit_down.localPosition = watch_game:Find("gaming_pos").localPosition
                end
            end

            show_sit_down()

            UI.OnClick(sit_down, nil, function()
                coroutine.wrap(function()
                    server.sit_down()
                    local new_room_data = require "game".wait_enter()
                    if new_room_data then
                        player_data.room_data = new_room_data
                        is_reconnect = true
                        close()
                    end
                end)()
            end)
        else
            startgame.position = transform:Find("waiting/prepare").position
            show_sit_down = function()
                if not player_can_start() then
                    invite_center()
                end
            end
        end
        show_visitor_info, show_watch_btn = init_visit_list(watch_game:Find("list"))
    end

    local function can_startgame()
        if show_sit_down then
            show_sit_down()
        end

        UI.Active(startgame, false)

        if not game_cfg.CAN_MID_ENTER and not room_data.can_visit_enter then
            return
        end

        if room_data.start_count ~= 0 then
            return
        end

        if not player_can_start() then
            return
        end

        UI.Active(transform:Find("waiting"), true)
        UI.Active(startgame, true)

        local ready_count = 0
        for _, role in pairs(role_tbl) do
            if role.data.is_ready then
                ready_count = ready_count + 1
            end
        end

        local player_size = table.length(role_tbl)
        if room_data.is_visit then
            player_size = player_size - 1
        end

        local mask = startgame:Find("mask")
        local enable = ready_count < 2 or ready_count ~= player_size

        if mask then
            UI.Active(mask, enable)
        else
            UI.Active(startgame, not enable)
        end
    end

    server.listen(msg.READY, function(id, is_ready, count)
        if id == player_id then
            prepare.value = is_ready
        end
        if role_tbl[id] then
            role_tbl[id].data.is_ready = is_ready
            role_tbl[id].prepare(is_ready)
        end

        if count == room_data.player_size then
            hide_waiting()
            room_data.start_count = room_data.round
            for _, role in pairs(role_tbl) do
                role.start()
            end
        end

		can_startgame()
    end)

    server.listen(msg.DISMISS, function()
        show_hint("房间已经解散！", 1)
        player_data.room_data = nil
        close()
    end)

    server.listen(msg.ROOM_OUT, function(pid)
        local role = role_tbl[pid]
        local is_visit = room_data.is_visit
        if not (role or is_visit) then
            return
        end
        
        if role then
            role.clear()
        end
        if pid == player_id then
            player_data.room_data = nil
            close()
            show_hint("已经退出房间！")
            if is_visit then
                return
            end
        end
        role_tbl[pid] = nil
        can_startgame()
    end)

    server.listen(msg.APPLY, function(dismiss_tbl, dismiss_time)
        show_apply(transform, {
            player_name = role_tbl[player_id].data.name,
            player_id = player_id,
            role_tbl = get_room_players(role_tbl),
            dismiss_tbl = dismiss_tbl,
            dismiss_time = dismiss_time
        }, function()
            show_hint("房间已经解散！", 1)
            player_data.room_data = nil
            close()
        end)
    end)

    server.listen(msg.VISITOR_LIST, function(visit_player)
        if type(visit_player) == "table" then
            for id, name in pairs(visit_player) do
                show_visitor_info(id, name, true)
            end
        else
            show_visitor_info(visit_player, false)
        end
    end)

    local on_init_role
    server.listen(msg.INIT, function(data, distance)     --观战状态进入游戏
        if room_data.is_visit then
            if room_is_full(-1 + (role_tbl[data.id] and 0 or 1)) then
                distance = 0
            else
                if distance >= 0 then
                    distance = distance + 1
                end
            end
        end
        
        data.src_distance = distance
        if distance < 0 then
            distance = distance + room_data.player_size
        end
        data.distance = distance
        data.role_tbl = role_tbl

        if role_tbl[data.id] then
            data = table.merge(role_tbl[data.id].data, data)
        end

        on_init_role(data)

        local role = role_tbl[data.id]
        role.online(data.ip ~= nil)
        if data.ip ~= nil then
            role.pause(data.is_pause)
        end

        if room_data.start_count == room_data.round then
            hide_waiting()
            role.start(true)
        else
            role.prepare(data.is_ready)
            if room_data.round > 1 then
                role.show_score()
            end
        end
        role.score(data.score)
        can_startgame()
    end)

    server.listen(msg.START_GAME, function()
        room_data.start_count = room_data.round
        hide_waiting()
        can_startgame()
    end)

    local game_player_data = table.copy(player_data)
    game_player_data.id = player_id

    on_init_role, role_tbl, on_close = init_game(game_player_data, transform, close)

    player_data.role_tbl = role_tbl

    if room_data.start_count == room_data.round then
        if role_tbl[player_id] then
            role_tbl[player_id].start(true)
        end
    elseif room_data.round > 1 then
        if role_tbl[player_id] then
            role_tbl[player_id].show_score()
        end
    end

    return function()
        close()
    end
end
