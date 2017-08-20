--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local GameObject = UnityEngine.GameObject
local AudioSource = UnityEngine.AudioSource
local PlayerPrefs = UnityEngine.PlayerPrefs

return function(bgm_name)
    local transform = GameObject.Find("UI Root/Camera").transform
    local audio = transform:GetComponent(AudioSource)
    
    local clip = UI.LoadAudio(bgm_name)
    audio.clip = clip
    audio.volume = PlayerPrefs.GetFloat("VOLUME_BGM", 0.6)
    audio:Play()
end