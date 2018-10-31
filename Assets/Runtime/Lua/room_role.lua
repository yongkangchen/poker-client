--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local AudioSource = UnityEngine.AudioSource
local GameObject = UnityEngine.GameObject
local singleton_timer = UI.singleton_timer
local PlayerPrefs = UnityEngine.PlayerPrefs

local show_info = require "room_info"

return function(parent, data, distance)
    UI.Active(parent, true)
    local info_trans = parent:Find("role(Clone)")
    if not info_trans then
        info_trans = UI.InitPrefab("role", parent) 
    end
    UI.Active(info_trans, true)

    local start_pos = parent:Find("pos/start").position
    info_trans.position = parent:Find("pos/ready").position

    local smaile_trans = UI.Child(info_trans, "smile")

    local name_lab = UI.GetComponent(info_trans, "name", UILabel)
    name_lab.text = UI.LimitName(data.name)

    local score_lab = UI.GetComponent(info_trans, "score", UILabel)
    local ip_warning = UI.Child(info_trans, "ip_warning")
    local offline_sign = UI.Child(info_trans, "offline")
    local is_mid_enter = UI.Child(info_trans, "is_mid_enter")
    UI.Active(is_mid_enter, data.is_mid_enter == true)

    local icon = UI.Child(info_trans, "icon")
    local icon_pause = UI.Child(info_trans, "pause")
    
    local eff_tween_rot = icon:GetComponent(TweenRotation)
    local eff_tween_scale = icon:GetComponent(TweenScale)

    UI.OnClick(icon, nil, function()
        show_info(data)
    end)

    local player_pic = UI.Child(icon, "pic")
    local player_texture = player_pic:GetComponent(UITexture)
    local player_default_pic = player_texture.mainTexture

    UI.RoleHead(player_pic, data.headimgurl)

    data.distance = data.distance or 0
    distance = distance or data.distance

    local ok = UI.Child(info_trans, "ok/" .. distance)
    local not_ok = UI.Child(info_trans, "not_ok/" .. distance)
    
    local eff_voice_output = UI.Child(info_trans, "voiceOutput")
    local function show_eff_voice_output(v, is_text)
        eff_tween_rot.enabled = v
        eff_tween_scale.enabled = v
        if v then
            eff_tween_rot:ResetToBeginning()
            eff_tween_scale:ResetToBeginning()
        else
            icon.localRotation = UnityEngine.Vector3.zero
        end
        
        if not is_text then
            if v then
                UI.Active(eff_voice_output, not v)
            end
            UI.Active(eff_voice_output, v)
        end        
    end

    local bgm = GameObject.Find("UI Root/Camera").transform:GetComponent(AudioSource)
    local voice_eff_timer = singleton_timer()
    local function show_eff_voice(wait_time, is_text)
        show_eff_voice_output(true, is_text)

        if bgm.volume > 0.1 * PlayerPrefs.GetFloat("VOLUME_BGM", 0.6) then
            bgm.volume = 0.1 * PlayerPrefs.GetFloat("VOLUME_BGM", 0.6)
        end

        voice_eff_timer(wait_time * 1000, function()
            bgm.volume = PlayerPrefs.GetFloat("VOLUME_BGM", 0.6)
            show_eff_voice_output(false, is_text)
        end)
    end

    local play_audio = smaile_trans:GetComponent(AudioSource)
    local zhuang = info_trans:Find("zhuang")
    local msg_start = info_trans:Find("msg_start")
    local offline_timer
    UI.OnDestroy(info_trans, function()
        if offline then
            LuaTimer.Delete(offline_timer)
            offline_timer = nil
        end
    end)

    return {
        get_pos = function()
            return start_pos
        end,
        move_to = function(v)
            TweenPosition.Begin(info_trans.gameObject, 0.2, v, true).delay = 1.5
        end,
        start = function(skip_tween)
            UI.Active(ok, false)
            if skip_tween then
                info_trans.position = start_pos
                UI.Active(info_trans:Find("score"), true)
            else
                local comp = TweenPosition.Begin(info_trans.gameObject, 0.2, start_pos, true)
                EventDelegate.Add(comp.onFinished, function()
                    UI.Active(info_trans:Find("score"), true)
                end)
            end
        end,
        show_score = function()
            UI.Active(info_trans:Find("score"), true)
        end,
        zhuang = function(v)
            UI.Active(zhuang, v)
        end,
        clear = function()
            name_lab.text = ""
            score_lab.text = ""
            UI.Active(ip_warning, false)
            UI.Active(ok, false)
            UI.Active(not_ok, false)
            player_texture.mainTexture = player_default_pic
            UI.Active(info_trans, false)
        end,
        play_voice = function(v)
            play_audio.clip = v
            play_audio.volume = UI.GetVolume()
            play_audio.time = 0
            play_audio:Stop()
            play_audio:Play()

            show_eff_voice(v.length)
        end,
        ip_warning = function(_)
            -- UI.Active(ip_warning, false)
        end,
        online = function(v)
            local time_ui = offline_sign:Find("time")
            if v then
                UI.SpriteColorChange(icon, 255.0, 255.0, 255.0, 255.0)
                UI.SpriteColorChange(player_pic, 255.0, 255.0, 255.0, 255.0)
                
                if not time_ui then
                    return
                end
                if offline then
                    LuaTimer.Delete(offline_timer)
                    offline_timer = nil
                end
            else
                UI.Active(icon_pause, v)
                UI.SpriteColorChange(icon, 128.0, 128.0, 128.0, 128.0)
                UI.SpriteColorChange(player_pic, 128.0, 128.0, 128.0, 128.0)

                if not time_ui then
                    return
                end
                local offline_time = os.time()
                offline_timer = LuaTimer.Add(0, 1000, function()
                    local secends = os.time() - offline_time
                    local secends_word
                    local hores_word
                    if secends >= 6000 then
                        secends_word = 60
                        hores_word = 99
                    else
                        secends_word = string.format("%02d", secends % 60)
                        hores_word = string.format("%02d", math.floor(secends / 60))
                    end

                    UI.Label(offline_sign, "time", hores_word .. ":" .. secends_word)

                    return true
                end)
            end
            UI.Active(offline_sign, not v)

        end,
        pause = function(v)
            if v then
                UI.SpriteColorChange(player_pic, 128.0, 128.0, 128.0, 128.0)
            else
                UI.SpriteColorChange(player_pic, 255.0, 255.0, 255.0, 255.0)
            end
            UI.Active(icon_pause, v)
        end,
        prepare = function(v)
            UI.Active(ok, v)
            UI.Active(not_ok, not v)
        end,
        get_smile_parent = function()
            return smaile_trans
        end,
        score = function(v)
            score_lab.text = tostring(v)
        end,
        show_eff_voice = show_eff_voice,
        hide_ready_status = function()
            UI.Active(ok, false)
            UI.Active(not_ok, false)
        end,
        hide_mid_enter = function()
            UI.Active(is_mid_enter, false)
        end,
        show_msg = function(content, all_ready)
            local name
            if all_ready then
                name = (distance == 0 or distance == 3 ) and 0 or  1
            else 
                name = distance == 3 and 1 or  0
            end
            
            UI.Active(msg_start:Find("msg_bg_"..name), true)
            
            local label = msg_start:Find("msg_bg_"..name.."/content"):GetComponent(UILabel)
            local bg = msg_start:Find("msg_bg_"..name):GetComponent(UI2DSprite)
            bg.alpha = 1
            label.text = content
            bg.width = label.width + 52
            bg.height = label.height + 37
            
            local alpha = msg_start:Find("msg_bg_"..name):GetComponent(TweenAlpha)
            alpha:Play(true)
        end,
        show_trust = function(v)
            UI.Active(info_trans:Find("trust"), v)
        end
    }
end
