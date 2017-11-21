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
local msg = require "data.msg"
local show_hint = require "hint"

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

    server.listen(msg.HINT, function(hint)
        show_hint(hint, 3)
    end)
    
    local pid = get_login()
    
    local player_data = server:login(pid)
    
    local room_id = player_data.room_id
    player_data.room_id = nil
    
    PlayerPrefs.SetString(LOGIN_SAVE_KEY, table.dump({id = player_data.id}))
    
    player_data.room_data = room_id and server:get_room() or nil
    
    LLOG("login success, pid: %d", player_data.id)
    return player_data
end