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

local function get_room_players(role_tbl)
    local tbl = {}
    for role_id, role in pairs(role_tbl) do
        local role_data = role.data
        role_data.id = role_id
        tbl[role_data.idx or 1] = role_data
    end
    return tbl
end

return function(init_game, player_data, on_over)
    local on_close
    local room_data = player_data.room_data
    local player_id = player_data.id

    if room_data.visitor_id then
        player_id = room_data.visitor_id
        room_data.is_visit = true
    end

    local role_tbl

    local transform = UI.InitPrefab("room")
    local function close(is_over)
        transform:GetComponent(UIPanel).depth = -1
        Destroy(transform.gameObject, 0.06)
        if player_data.room_data then
            if type(is_over) ~= "boolean" then
                is_over = player_data.room_data.round == player_data.room_data.max_round
            end
            if not is_over then
                player_data.room_data.round = player_data.room_data.round + 1
            else
                player_data.room_data = nil
            end
        end

        on_over()

        if on_close then
            local ok, err = pcall(on_close)
            if not ok then
                LERR("room on_close err: %s", err)
            end
        end
    end

    local function do_quit()
        -- LERR("room_data: %s", table.dump(room_data))
        if room_data.is_visit or (room_data.host_start and room_data.start_count == 0 and room_data.host_id == player_id) then
            server.room_out()
            player_data.room_data = nil
            close()
            return
        end

        if room_data.start_count == 0 then
            local is_host = room_data.host_id == player_id
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

        if room_data.is_visit then
            local sit_down = transform:Find("sit_down")
            if sit_down then
                sit_down.localPosition = UnityEngine.Vector3(0, 0, 0)
            end
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

    local startgame = UI.Child(transform, "waiting/startgame")
    UI.Active(startgame, false)

    UI.OnClick(transform, "waiting/startgame", function()
        server.start_game()
    end)

    local show_sit_down
    if room_data.can_visit_enter then
        UI.Active(transform:Find("waiting/prepare"), false)
        UI.Active(transform:Find("waiting/cancel"), false)

        if room_data.is_visit then
            local sit_down = transform:Find("sit_down")
            if sit_down then
                show_sit_down = function()
                    UI.Active(sit_down, room_data.is_visit and room_data.player_size > (table.length(role_tbl) - 1))
                end

                UI.OnClick(sit_down, nil, function()
                    server.enter()
                end)

                if room_data.start_count > 0 then
                    sit_down.localPosition = UnityEngine.Vector3(0, 0, 0)
                else
                    show_sit_down()
                end
            end
        else
            if room_data.host_start and player_id == room_data.host_id then
                UI.Active(transform:Find("waiting/invite"), false) --TODO: 这里要处理？
                UI.Active(transform:Find("waiting"), true)
            end
        end
    end

    local function can_startgame()
        UI.Active(startgame, false)

        if not cfg.CAN_MID_ENTER and not room_data.can_visit_enter then
            return
        end
        
        if room_data.start_count ~= 0 then
            return
        end

        if room_data.auto_start_type then
            if room_data.auto_start_type ~= 1 then
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
        
        local ready_count = 0
        for _, role in pairs(role_tbl) do
            if role.data.is_ready then
                ready_count = ready_count + 1
            end
        end

        if ready_count < 2 then
            return
        end

        local player_size = table.length(role_tbl)
        if room_data.is_visit then
            player_size = player_size - 1
        end

        if ready_count ~= player_size then
            return
        end

        UI.Active(transform:Find("waiting"), true)
        UI.Active(startgame, true)
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
        if not role then
            return
        end

        role.clear()
        if pid == player_id then
            player_data.room_data = nil
            close()
            show_hint("已经退出房间！")
        end
        role_tbl[pid] = nil
        if show_sit_down then
            show_sit_down()
        end
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

    server.listen(msg.VISITOR, function(visit_player, is_sit)
        if player_data.id == visit_player and is_sit then
            room_data.is_visit = nil
            if on_close then
                on_close()
            end
            return
        end

        -- if type(visit_player) == "table" then
        --     --TODO: 填充数据
        -- else
        --     --TODO: 删除
        -- end
    end)

    local on_init_role
    server.listen(msg.INIT, function(data, distance)     --观战状态进入游戏
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

        if room_data.host_start then  --房主坐下
            can_startgame()
        end

        if show_sit_down then
            show_sit_down()
        end
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
