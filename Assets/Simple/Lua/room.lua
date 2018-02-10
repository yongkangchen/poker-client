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

local function player_can_start(player_data)
    local room_data = player_data.room_data
    local player_id = player_data.id
    if room_data.auto_start_type then
        if room_data.auto_start_type ~= -1 then
            return
        end

        if player_id ~= room_data.host_id then
            return
        end
    else
        local can_start = false
        for _, role in pairs(player_data.role_tbl) do
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

local function init_watch_game(transform, player_data, simple_close)
    local room_data = player_data.room_data
    local player_id = player_data.id

    local waiting_btn = transform:Find("waiting")
    local startgame = waiting_btn:Find("startgame")
    local invite = waiting_btn:Find("invite")

    local watch_game = UI.InitPrefab("watch_game", transform)
    local sit_down = waiting_btn:Find("sit_down")

    if room_data.auto_start_type and room_data.auto_start_type == -1 and room_data.host_id == player_id and room_data.start_count == 0 then
        UI.Active(startgame:Find("mask"), true)
        local startgame_init_pos = watch_game:Find("startgame_init_pos")
        if startgame_init_pos then
            startgame.localPosition = startgame_init_pos.localPosition
        end
    else
        local sitdown_init_pos = watch_game:Find("sitdown_init_pos")
        if sitdown_init_pos then
            sit_down.localPosition = sitdown_init_pos.localPosition
        end
        UI.Active(startgame, false)
    end

    UI.OnClick(watch_game, "quit", function()
        if room_data.is_visit then
            server.room_out()
        end
    end)

    UI.Active(waiting_btn:Find("prepare"), false)
    UI.Active(waiting_btn:Find("cancel"), false)

    local function invite_center()
        if not player_can_start() then
            invite.localPosition = watch_game:Find("invite_pos")
        end
    end

    local function room_is_full(offset)
        local count = table.length(player_data.role_tbl or {}) + offset
        if count >= room_data.player_size or (room_data.max_player_size and count >= room_data.max_player_size) then
            return true
        end
    end

    local bg_tween = UI.GetComponent(watch_game, "bg", TweenPosition)
    local show_sit_down
    if room_data.is_visit then
        show_sit_down = function()
            if room_data.start_count > 0 then
                sit_down.localPosition = watch_game:Find("sitdown_gaming_pos").localPosition
                UI.Active(watch_game:Find("bg"), true)
		UI.Active(watch_game:Find("quit"), true)
                if bg_tween then
                    bg_tween.enabled = true
                end

                UI.Active(invite, false)

                if room_data.stop_mid_enter then
                    UI.Active(sit_down, false)
                    return
                end
            end

            local offset = -1
            if player_data.role_tbl and not player_data.role_tbl[player_id] then
                offset = 0
            end
            local active = room_data.is_visit and not room_is_full(offset)
            UI.Active(sit_down, active)

            if not active then
                invite_center()
            end
        end

        show_sit_down()

        UI.OnClick(sit_down, nil, function()
            coroutine.wrap(function()
                server.sit_down()
                local new_room_data = game.wait_enter()
                if new_room_data then
                    player_data.room_data = new_room_data
                    simple_close()
                end
            end)()
        end)
    else
        startgame.position = watch_game:Find("start_pos").position
        show_sit_down = function()
            if not player_can_start(player_data) then
                invite_center()
            end
        end
    end

    local show_visitor_info, show_watch_btn = init_visit_list(watch_game:Find("list"))
    server.listen(msg.VISITOR_LIST, function(visit_player)
        if type(visit_player) == "table" then
            for id, name in pairs(visit_player) do
                show_visitor_info(id, name, true)
            end
        else
            show_visitor_info(visit_player, false)
        end
    end)
    return show_sit_down, show_watch_btn
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

    local function simple_close()
        is_reconnect = true
        close()
    end

    local function do_quit()
        -- LERR("room_data: %s", table.dump(room_data))
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

    UI.OnClick(transform, "buttons/quit", do_quit)
    UI.OnClick(transform, "buttons/setting", function()
        show_dialog("确认重新加载游戏？", function()
            UnityEngine.SceneManagement.SceneManager.LoadScene(0)
        end, function() end)
    end)

    UI.Active(transform:Find("buttons/voice"), false)
    UI.Active(transform:Find("buttons/chat"), false)

    local waiting_btn = transform:Find("waiting")
    local prepare = UI.GetComponent(waiting_btn, "prepare", UIToggle)
    if not player_data.is_playback then
        EventDelegate.Add(prepare.onChange, function()
            server.ready(prepare.value)
        end)

        server.renter()

        if room_data.round ~= 1 then
            server.ready(true)
        end
    end

    local startgame = waiting_btn:Find("startgame")
    UI.OnClick(startgame, nil, function()
        server.start_game()
    end)

    local show_sit_down
    local show_watch_btn

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

        if not player_can_start(player_data) then
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
            if role_tbl and role_tbl[player_id] then
                player_size = player_size - 1
            end
        end

        local mask = startgame:Find("mask")
        local enable = ready_count < 2 or ready_count ~= player_size

        if mask then
            UI.Active(mask, enable)
        else
            UI.Active(startgame, not enable)
        end
    end

    local invite = waiting_btn:Find("invite")
    local function hide_waiting()
        if room_data.can_visit_enter then
            UI.Active(invite, false)
        else
            UI.Active(waiting_btn, false)
        end

        local blink = transform:Find("desk/blink")
        if blink then
            UI.Active(blink, true)
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

        if count == room_data.player_size and (not room_data.auto_start_type or room_data.auto_start_type ~= -1) then
            room_data.start_count = room_data.round
            hide_waiting()
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

    local on_init_role
    server.listen(msg.INIT, function(data, distance)
        if room_data.is_visit then
            local count = table.length(role_tbl or {})
            if role_tbl then
                if role_tbl[player_id] then
                    count = count - 1
                end

                if not role_tbl[data.id] then
                    count = count + 1
                end
            end

            if count >= room_data.player_size or (room_data.max_player_size and count >= room_data.max_player_size) then
                distance = 0
            else
                if distance >= 0 then
                    distance = distance + 1
                end
            end
        end

        data.src_distance = distance

        if distance < 0 then
            distance = distance + (room_data.all_player_size or room_data.player_size)
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

    if room_data.can_visit_enter then
        show_sit_down, show_watch_btn = init_watch_game(transform, player_data, simple_close)
    else
        UI.Active(startgame, false)
        if room_data.round ~= 1 then
            UI.Active(waiting_btn, false)
        end
    end

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
