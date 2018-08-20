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

return function(text, sec)
    sec = sec or 1
    local transform = UI.InitPrefab("hint")
    local bg = transform:Find("bg"):GetComponent(UI2DSprite)
    local label = transform:Find("text"):GetComponent(UILabel)
    UI.Label(transform, "text", text)
    bg.width = label.width + 100

    local tweens = transform:GetComponents(TweenAlpha)
    if tweens and tweens.Length >= 2 then
        local tween = tweens[2]
        sec = tween.delay + tween.duration
    end

    Destroy(transform.gameObject, sec)
end
