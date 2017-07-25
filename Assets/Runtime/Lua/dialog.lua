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
    
    local prefab = ResourcesLoad("prefabs/dialog")
    local gameObject = UnityEngine.Object.Instantiate(prefab)
    local transform = gameObject.transform

    transform:SetParent(UnityEngine.GameObject.Find("UI Root").transform, false)
    transform:Find("text"):GetComponent(UILabel).text = text
    
    UIEventListener.Get(transform:Find("ok").gameObject).onClick = function()
        Destroy(transform.gameObject)
        if on_ok then
            on_ok()
        end
    end
    
    UIEventListener.Get(transform:Find("close").gameObject).onClick = function()
        Destroy(transform.gameObject)
        if on_close then
            on_close()
        end
    end
end
