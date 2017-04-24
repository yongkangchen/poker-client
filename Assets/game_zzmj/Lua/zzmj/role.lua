--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local Instantiate = UnityEngine.Object.Instantiate
local Destroy = UnityEngine.Object.Destroy
local AudioSource = UnityEngine.AudioSource
local Vector3 = UnityEngine.Vector3
local PlayerPrefs = UnityEngine.PlayerPrefs
local GameObject = UnityEngine.GameObject

local init_room_role = require "room_role"

local function sprite_name(value)
    return "tile_me_" .. value
end
local function sound_name(value)
    return tostring(value)
end

local function init_card(card, on_click)
    local obj
    local init_pos
    local active
    if on_click then
        init_pos = card.localPosition
        
        local box = GameObject().transform
        box:SetParent(card.parent, false)
        card:SetParent(box, false)
        
        box.localPosition = init_pos
        init_pos = Vector3.zero
        card.localPosition = init_pos
        
        active = function(v)
            UI.Active(box, v)
            UI.Active(card, v)
        end
        
        UIEventListener.Get(card.gameObject).onClick = function()
           on_click(obj)
       end

        local sprite = card:GetComponent(UI2DSprite)
        local light = card:Find("light"):GetComponent(UI2DSprite)
        local start_y = card.localPosition.y
        local init_sprite_depth = sprite.depth
        local init_light_depth = light.depth
        UI.OnDragStart(card, nil, function()
            sprite.depth = 99
            light.depth = 100
        end)

        UI.OnDrag(card, nil, function(_, delta)
            local width = NGUITools.screenSize.x
            card.localPosition  = card.localPosition + Vector3(delta.x * 1024 / width, delta.y * 1024 / width, 0)
        end)
        
        UI.OnDragEnd(card, nil, function()
            if card.localPosition.y - start_y >= 150 then
                on_click(obj, true)
            else
                card.localPosition = init_pos
            end
            sprite.depth = init_sprite_depth
            light.depth = init_light_depth
        end)
    else
        active = function(v)
            UI.Active(card, v)
        end
    end
    
    local data
    obj = {
        toggle = function(value)
            card.localPosition = value and (init_pos + Vector3(0, 20, 0)) or init_pos
        end,
        set_data = function(_data)
            data = _data
            if data then
                active(true)
                if init_pos then
                    card.localPosition = init_pos
                end
                if type(data) ~= "boolean" then
                    UI.Sprite(card, "light", sprite_name(data))
                end
            else
                active(false)
            end
        end,
        get_data = function()
            return data
        end
    }
    return obj
end

local function init_hand(hand, new_card, click_hand)
    local hand_init = false
    local hand_grid = hand:GetComponent(UIGrid)
    local hand_tbl = UI.Children(hand)
    local audio = new_card:GetComponent(AudioSource)
    local click_audio = hand.parent:GetComponent(AudioSource)
    
    local on_click
    if click_hand then
        local last_card
        on_click = function(card, drag_out)
            click_audio.volume = UI.GetVolume()
            click_audio:Play()
            
            if last_card then
                last_card.toggle(false)
            end
            
            LERR("last_card: %s, card: %s, drag_out: %s, %s", tostring(last_card), tostring(card), tostring(drag_out), card.get_data())
            if last_card == card or drag_out then
                last_card = nil
                if click_hand(card.get_data()) then
                    card.set_data()
                    hand_grid:Reposition()
                else
                    card.toggle(false)
                end
                return
            end
            
            last_card = card
            last_card.toggle(true)
        end
    end
    
    for i, card in ipairs(hand_tbl) do
        hand_tbl[i] = init_card(card, on_click)
    end
    new_card = init_card(new_card, on_click)
    
    return function(tbl, new_idx)
        if not hand_init then
            hand_init = true
            UI.Active(hand, true)
        end

        if new_idx then
            audio.volume = UI.GetVolume()
            audio:Play()
            new_card.set_data(true)
        else
            new_card.set_data()
        end

        if type(tbl) == "table" then
            local old_idx = table.index(hand_tbl, new_card)
            if old_idx then
                table.remove(hand_tbl, old_idx)
            end

            if new_idx then
                table.insert(hand_tbl, new_idx, new_card)
            end

            for i, card in ipairs(hand_tbl) do
                card.set_data(tbl[i])
            end
        else
            if new_idx then
                tbl = tbl - 1
            end
            for i, card in ipairs(hand_tbl) do
                card.set_data(i <= tbl)
            end
        end
        hand_grid:Reposition()
    end
end

local function init_out(out)
    local out_grid = out:GetComponent(UIGrid)
    local add_depth = (out.parent.name == "2" or out.parent.name == "3") and 1 or -1
    return function(tbl)
        local out_tbl = UI.Children(out)
        local card
        for i, value in ipairs(tbl) do
            card = out_tbl[i]
            if not card then
                card = Instantiate(out_tbl[1]).transform
                card:SetParent(out, false)
                local sprite = card:GetComponent(UI2DSprite)
                sprite.depth = sprite.depth + i * add_depth
                out_tbl[i] = card
            end
            UI.Active(card, true)
            UI.Sprite(card, "light", sprite_name(value))
        end

        for i = #tbl + 1, #out_tbl do
            UI.Active(out_tbl[i], false)
        end

        out_grid:Reposition()
        return card and card.position or nil
    end
end

local function init_sound(transform)
    local audio = transform:GetComponent(AudioSource)
    return function(name, skip_sex, skip_random)
        
        local is_cs = PlayerPrefs.GetInt("open", 1) == 1
        
        if not skip_random then
            name = is_cs and name .. math.random(1, 2) or name
        end

        if not skip_sex then
            name = "10".. name
        end
        --LERR("sound name %s", name)
        local res_url = "zzmj/"
        if is_cs and name ~= "out1"then
            res_url = "zzmj/cs/"
        end
        local clip = UI.LoadAudio(res_url .. name)
        audio.clip = clip
        audio.volume = UI.GetVolume()
        audio:Play()
    end
end

local function play_animation(transform)
    UI.Active(transform, false)
    UI.Active(transform, true)
end

return function(transform, data, click_hand)
    local play_sound = init_sound(transform)

    local out_flag = transform:Find("out_flag")
    local ani_shouhua = out_flag:Find("ani_shouhua")
    local card_parent = transform:Find("card")
    local card_grid = card_parent:GetComponent(UITable)

    local show_hand
    if data.is_playback then
        show_hand = init_hand(card_parent:Find("hand_m"), transform:Find("new_m"), click_hand)
    else
        show_hand = init_hand(card_parent:Find("hand"), transform:Find("new"), click_hand)
    end
    
    local show_out = init_out(transform:Find("out"))

    local effect = transform:Find("effect")
    local extra_path
    if transform.name == "0" or transform.name == "2" then
        extra_path = "card/extra"
    else
        extra_path = "extra"
    end

    local extra = transform:Find(extra_path)

    local extra_grid = extra:GetComponent(UIGrid)
    local extra_cards = UI.Children(extra)

    local play_out_sound = init_sound(transform:Find("now_out"))

    local function create_extra(type, data_tbl, skip_sound)
        local cards = Instantiate(extra_cards[type]).transform
        cards:SetParent(extra, false)
        UI.Active(cards, true)

        local card_tbl = UI.Children(cards)
        for i, value in ipairs(data_tbl) do
            UI.Sprite(card_tbl[i], "light", sprite_name(value))
        end
        extra_grid:Reposition()
        if not skip_sound then
            local audio = cards:GetComponent(UnityEngine.AudioSource)
            audio.enabled = true
            audio.volume = UI.GetVolume()
            audio:Play()
        end
        --card_grid.repositionNow = true
        return cards.gameObject
    end

    local peng_tbl = {}
    local pointer = transform:Find("pointer")
    local now_out = transform:Find("now_out")
    local now_out_timer
    local function clear_now_out_timer()
        if not now_out_timer then
            return
        end
        LuaTimer.Delete(now_out_timer)
        now_out_timer = nil
    end
    local base_role = init_room_role(transform, data)
    local base_start = base_role.start
    return table.merge(base_role, {
        sprite_name = sprite_name,
        add_an_gang = function(value, skip_sound, sex, is_kai_gang)
            if not skip_sound then
                play_sound(not is_kai_gang and "gang" or "bu", sex ~= 2)
                local gang_effet = effect:Find(not is_kai_gang and "gang_an/words" or "bu/words")
                play_animation(gang_effet)
            end
            create_extra(1, {value}, skip_sound)
        end,
        add_gang = function(value, skip_sound, sex, is_kai_gang)
            if not skip_sound then
                play_sound(not is_kai_gang and "gang" or "bu", sex ~= 2)
                local gang_effet = effect:Find(not is_kai_gang and "gang_ming/words" or "bu/words")
                play_animation(gang_effet)
            end
            create_extra(2, {value, value, value}, skip_sound)
        end,
        add_eat = function(v, skip_sound, sex)
            if not skip_sound then
                play_sound("chi", sex ~= 2)
                local chi_effet = effect:Find("chi/words")
                play_animation(chi_effet)
            end
            create_extra(3, v, skip_sound)
        end,
        add_peng = function(value, skip_sound, sex)
            if not skip_sound then
                play_sound("peng", sex ~= 2)
                local peng_effet = effect:Find("peng/words")
                play_animation(peng_effet)
            end
            peng_tbl[value] = create_extra(3, {value, value, value}, skip_sound)
        end,
        remove_peng = function(value)
            UI.Active(peng_tbl[value], false)
            Destroy(peng_tbl[value])
        end,
        show_hand = function(...)
            show_hand(...)
            card_grid.repositionNow = true
        end,
        set_now_out = function(card)
            UI.Active(now_out, true)
            UI.Sprite(now_out, "light", sprite_name(card))
        end,
        show_out = function(v, card, show_pointer, sex)
            if card then
                UI.Active(now_out, true)
                UI.Sprite(now_out, "light", sprite_name(card))
                play_out_sound("out1", true, true)
                play_sound(sound_name(card), sex ~= 2, true)
                local pos = show_out(v)
                if pos then
                    UI.Active(pointer, true)
                    pointer.position = pos
                end
                now_out_timer = LuaTimer.Add(500, function()
                    now_out_timer = nil
                    UI.Active(now_out, false)
                end)
            else
                local pos = show_out(v)
                if show_pointer and pos then
                    UI.Active(pointer, true)
                    pointer.position = pos
                end
            end
        end,
        hide_pointer = function()
            UI.Active(pointer, false)
            clear_now_out_timer()
            UI.Active(now_out, false)
        end,
        now_out = function(v)
            clear_now_out_timer()
            UI.Active(now_out, v)
        end,
        play_hu = function(sex, zimo)
            play_sound(zimo and "zimo" or "hu", sex ~= 2, zimo)
        end,
        out_flag = function(v, skip_show)
            UI.Active(out_flag, v)
            if ani_shouhua then
                UI.Active(ani_shouhua, not skip_show)
            end
        end,
        show_eff = function(name)
            local eff = effect:Find(name)
            play_animation(eff)
        end,
        start = function(...)
            local dirs = UI.Children(transform:Find("dir"))
            for i, v in ipairs(dirs) do
                UI.Active(v, i == data.idx)
            end
            UI.Active(transform.parent.parent:Find("desk/blink"), true)
            return base_start(...)
        end,
    })
end
