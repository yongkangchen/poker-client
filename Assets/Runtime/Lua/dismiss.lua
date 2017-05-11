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

return function(transform, is_out, on_ok)    
    transform = UI.InitWindowX("dismiss", transform)
    local out_trans = transform:Find("title/quit")
    local dimiss_trans = transform:Find("title/dismiss")    
    
    UI.Active(out_trans, is_out)
    UI.Active(dimiss_trans, not is_out)
    
    UI.OnClick(transform, "yes", function()
        Destroy(transform.gameObject)
        on_ok()
    end)
    
    UI.OnClick(transform, "no", function()
        Destroy(transform.gameObject)
        return true
    end)
    
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
    end)
end
