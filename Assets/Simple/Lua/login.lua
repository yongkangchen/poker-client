--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local PlayerPrefs = UnityEngine.PlayerPrefs

local server = require "lib.server"

LOGIN_SAVE_KEY = "LOGIN_KEY:" .. UnityEngine.Application.dataPath
local function get_login()
    local data = table.undump(PlayerPrefs.GetString(LOGIN_SAVE_KEY)) or {}
    if type(data) ~= "table" then
        data = {}
    end

    local id = tonumber(data.id)
    if id then
        return id
    end
end

return function()
    local pid = get_login()

    local player_data = server:login(pid)

    local room_id = player_data.room_id
    player_data.room_id = nil

    PlayerPrefs.SetString(LOGIN_SAVE_KEY, table.dump({id = player_data.id}))

    if room_id then
        local room_data, is_visit = server:get_room()
        room_data.is_visit = is_visit
        player_data.room_data = room_data
    else
        player_data.room_data = nil
    end


    LLOG("login success, pid: %d", player_data.id)
    return player_data
end
