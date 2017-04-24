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

return function(text, on_ok, on_close)
    on_close = on_close or on_ok
    local transform = UI.InitWindow("dialog")
    UI.Label(transform, "text", text)
    UI.OnClick(transform, "ok", function()
        Destroy(transform.gameObject)
        if on_ok then
            on_ok()
        end
    end)
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
        if on_close then
            on_close()
        end
    end)
end
