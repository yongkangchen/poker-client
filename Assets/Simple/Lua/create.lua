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

return function(on_create)
    local transform = UI.InitWindow("create")
    local function close()
        Destroy(transform.gameObject)
    end
    UI.OnClick(transform, "back", close)
    
    UI.OnClick(transform, "create_list/create_free", function()
        on_create(close)
    end)
    
    return transform
end
