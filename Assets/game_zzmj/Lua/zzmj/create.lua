--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local function get_params(transform)
    local num = tonumber(UIToggle.GetActiveToggle(7).transform.parent.name)
    local can_pao = tonumber(UIToggle.GetActiveToggle(8).transform.parent.name)
    local horse = tonumber(UIToggle.GetActiveToggle(9).transform.parent.name)
    local seven_hu = transform:Find("op2/1/toggle"):GetComponent(UIToggle).value    
    return num, "zhuanzhuan", horse, nil, seven_hu, can_pao == 1
end

return function(set_number, transform, sub_name)
    local function update_number()
        local type_toggle = UIToggle.GetActiveToggle(100)
        if type_toggle == nil then
            return
        end
        
        local room_type = type_toggle.transform.name
        
        local round = UI.GetComponent(transform, "create(Clone)/"..room_type.."/op1/8/toggle", UIToggle).value and 1 or 2
        set_number(round)
    end
    
    EventDelegate.Add(transform:Find("select(Clone)/zz"):GetComponent(UIToggle).onChange, update_number)
    EventDelegate.Add(UI.GetComponent(transform, "create(Clone)/zz/op1/8/toggle", UIToggle).onChange, update_number)

    
    if sub_name then
        LuaTimer.Add(100, function()
            transform:Find("select(Clone)/" .. sub_name):GetComponent(UIToggle).value = true
        end)
    end
    
    return function()
        local room_type = UIToggle.GetActiveToggle(100).transform.name
        return get_params(transform:Find("create(Clone)/"..room_type))
    end
end
