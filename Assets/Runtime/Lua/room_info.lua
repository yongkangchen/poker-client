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

return function(data)
    local transform = UI.InitWindow("room_info")
    
    UI.Label(transform, "name/word", data.name)
    UI.Label(transform, "id", "ID: "..data.id)
    if data.ip then
        UI.Label(transform, "ip", "IP: "..data.ip)
    else
        UI.Label(transform, "ip", "IP: 离线")
    end
    
    UI.RoleHead(transform:Find("head/icon"), data.headimgurl)
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
    end)
    
    if require "game_cfg".APPSTORE then return end
    
    local dis_trans_tbl = UI.Children(transform:Find("distance"))
    if not data.lat or not data.lon then
        local dis_trans = dis_trans_tbl[2]
        UI.Active(dis_trans, true)
        UI.Label(dis_trans, "word", "【"..UI.LimitName(data.name).."】定位未开启")
    else
        local idx = 1 
        for role_id, role in pairs(data.role_tbl) do        
            if role_id ~= data.id then 
                local role_data = role.data
                local dis_trans = dis_trans_tbl[idx]
                UI.Active(dis_trans, true)
                if not role_data.lat or not role_data.lon then
                    UI.Label(dis_trans, "word", "【"..UI.LimitName(role_data.name).."】定位未开启")
                else
                    local gps_distance = ThirdDLL.GPSDistance(data.lat, data.lon, role_data.lat, role_data.lon)
                    if gps_distance > 999 then
                        gps_distance = ">999米"
                    else
                        gps_distance = gps_distance .. "米"
                    end
                    UI.Label(dis_trans, "word", "与【"..UI.LimitName(role_data.name).."】距离 "..gps_distance)
                end
                -- if data.ip and role_data.ip and role_data.ip ~= data.ip then
                --     UI.Active(dis_trans:Find("icon"), false)
                -- end
                idx = idx + 1
            end
        end
    end
end
