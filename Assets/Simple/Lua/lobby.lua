--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local show_mid_enter = require "mid_enter"
local msg = require "data.msg"
local server = require "lib.server"
local show_hint = require "hint"

local game = require "game"

local PlayerPrefs = UnityEngine.PlayerPrefs
local ENTER_ERROR = {
    [1] = "已在房间中，请退后台重试或联系客服。",
    [2] = "房间id号错误。",
    [3] = "房间已满。",
    [4] = "人数已达上限。",
    [6] = "游戏已经开始，无法进入房间。",
}

local CREATE_ERROR = {
    [1] = "已在房间中，请退后台重试或联系客服。",
}

return function(player_data)
    local transform = UI.InitPrefab("small_lobby")
    UI.Active(transform, false)

    UI.Label(transform, "id", player_data.id)
    UI.OnClick(transform, "ok", function()
        PlayerPrefs.SetString(LOGIN_SAVE_KEY, table.dump({id = tonumber(UI.GetComponent(transform, "id", UILabel).text)}))
        UnityEngine.SceneManagement.SceneManager.LoadScene(0)
    end)

    local do_enter_game
    local function enter_room(room_id)
        local room_data, is_visit = server:enter(room_id)
        local error = ENTER_ERROR[room_data]
        if error then
            show_hint(error)
            return false
        end

        room_data.is_visit = is_visit

        UI.Active(transform, false)
        do_enter_game(room_data)
        return true
    end

    local function create_room(game_name, money_type, num, ...)
        local room_data = server:create(game_name, money_type, num, ...)

        local error = CREATE_ERROR[room_data]
        if error then
            show_hint(error)
            return false
        end
        
        if room_data.can_visit_enter then
            room_data.is_visit = true
        end
        
        UI.Active(transform, false)
        do_enter_game(room_data)
        return true
    end

    local function mid_enter_room(...)
        server.enter(...)
    end
    server.listen(msg.MID_ENTER,function(room_data, ask_data)
        room_data.ask_data = ask_data
        show_mid_enter(room_data, mid_enter_room)
    end)

    game.init(transform, enter_room, create_room)
    game.wait_enter = function()
        local co = coroutine.running()
        server.listen(msg.ENTER, function(room_data, is_visit)
            if type(room_data) == 'table' then
                room_data.is_visit = is_visit
                coroutine.resume(co, room_data)
                return
            end

            local error = CREATE_ERROR[room_data]
            if error then
                show_hint(error)
                coroutine.resume(co)
                return
            end
        end)
        return coroutine.yield()
    end

    return function(func)
        UI.Active(transform, true)
        do_enter_game = func
    end
end
