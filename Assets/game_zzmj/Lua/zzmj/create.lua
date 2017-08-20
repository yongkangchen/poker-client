--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

return function()
    local num = tonumber(UIToggle.GetActiveToggle(1).transform.parent.name)
    local can_pao = tonumber(UIToggle.GetActiveToggle(3).transform.parent.name)
    local seven_hu = UIToggle.GetActiveToggle(4).value
    local horse = tonumber(UIToggle.GetActiveToggle(5).transform.parent.name)
    local peng_hu = false
    return num, horse, peng_hu, seven_hu, can_pao == 1
end