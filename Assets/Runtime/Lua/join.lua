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
return function(do_enter)
    local transform = UI.InitWindowX("join")
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
    end)

    local input = UI.Children(transform:Find("input"))
    local tip = transform:Find("input/tip")

    local idx = 0
    local num = 0

    local function delete()
        local v = input[idx]
        if not v then
            return
        end
        num = num - num % (10^(7-idx))
        UI.Sprite(v, "num", nil)
        idx = idx - 1
        if idx == 0 then
            UI.Active(tip, true)
        end
    end
    
    local function clear()
        for _ = 1, idx do
            delete()
        end
        UI.Active(tip, true)
    end
    
    for i = 0, 9 do
        UI.OnClick(transform, "keyboard/" .. i, function()
            if input[idx + 1] == nil then
                return
            end

            idx = idx + 1
            num = num + (10^(6 - idx)) * i
            UI.Sprite(input[idx], "num", "light_num_" .. i)

            UI.Active(tip, false)
            if idx ~= 6 then
                return
            end

            coroutine.wrap(function()
                if do_enter(num) then
                    Destroy(transform.gameObject)
                else
                    delete()
                end
            end)()
        end)
    end

    UI.OnClick(transform, "keyboard/del", delete)
    UI.OnClick(transform, "keyboard/clear", clear)
end