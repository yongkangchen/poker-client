--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local server = require "lib.server"
local show_hint = require "hint"

local game = require "game"
local PlayerPrefs = UnityEngine.PlayerPrefs
local ENTER_ERROR = {
    [1] = "已在房间中，请退后台重试或联系客服。",
    [2] = "房间id号错误。",
    [3] = "房间已满。",
    [4] = "人数已达上限。",
    [5] = "您的" .. UI.cash_type .. "不足，请去商城购买。",
    [6] = "游戏已经开始，无法进入房间。",
    [7] = "游戏升级维护中。",
}

local CREATE_ERROR = {
    [1] = "已在房间中，请退后台重试或联系客服。",
    [3] = "创建失败，您没有被授权。",
    [4] = "创建失败，授权人玉不足。",
    [5] = "您的" .. UI.cash_type .. "不足。",
    [6] = "您的" .. UI.cash_type .. "不足，请去商城购买。",
    [7] = "游戏升级维护中。",
}

return function(player_data)
    local transform = UI.InitPrefabX("small_lobby")
    UI.Active(transform, false)
    
    UI.Label(transform, "id", player_data.id)
    UI.OnClick(transform, "ok", function()
        PlayerPrefs.SetString(LOGIN_SAVE_KEY, table.dump({id = tonumber(UI.GetComponent(transform, "id", UILabel).text)}))
        UnityEngine.SceneManagement.SceneManager.LoadScene(0)
    end)
    
    local do_enter_game
    local function enter_room(room_id)
        local room_data = server:enter(room_id)

        if type(room_data) == "table" then
            UI.Active(transform, false)
            do_enter_game(room_data)
            return true
        end
        
        show_hint(ENTER_ERROR[room_data])
        return false
    end

    local function create_room(game_name, money_type, num, ...)
        local room_data = server:create(game_name, money_type, num, ...)

        if type(room_data) == "table" then
            UI.Active(transform, false)
            do_enter_game(room_data)
            return true
        end
        
        show_hint(CREATE_ERROR[room_data])
        return false
    end
    
    game.init(transform, {
        enter = enter_room,
        create = create_room, 
        get_coin_num = function()
            return 0
        end,
        get_cash_num = function()
            return 0
        end,
        buy = function() end
    })

    return function(func)
        UI.Active(transform, true)
        do_enter_game = func
    end
end
