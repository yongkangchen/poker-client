--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

return function(transform)
    local timer_id
    local function clear()
        if not timer_id then
            return
        end
        LuaTimer.Delete(timer_id)
        timer_id = nil
    end
    
    UI.OnDestroy(transform, clear)
    
    return function()
        clear()
        
        local cur_time = 15
        UI.Active(transform:Find("desk/out_time"), true)
        UI.Label(transform, "desk/out_time", cur_time)
        timer_id = LuaTimer.Add(1000, 1000, function()
            cur_time = cur_time > 1 and cur_time - 1 or 0 
            UI.Label(transform, "desk/out_time", cur_time)
            if cur_time == 0 then 
                timer_id = nil
                return false
            end
            return true
        end)
    end
end
