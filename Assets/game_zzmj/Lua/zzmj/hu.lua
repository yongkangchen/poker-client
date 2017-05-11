--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local check_dict_hu = require "zzmj.lib.hu"

local function check_hu(hand, seven_hu, is_dict)
    local dict
    if is_dict then
        dict = hand
    else
        dict = {}
        for _, v in ipairs(hand) do
            dict[v] = (dict[v] or 0) + 1
        end
    end
    
    local ret = check_dict_hu(dict, seven_hu)
    if ret then
        return true
    end
end
return check_hu
