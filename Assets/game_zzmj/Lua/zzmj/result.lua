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
local function sprite_name(value)
    return "tile_me_" .. value
end

local function get_extra_type(v)
    if v.num == 3 then
        if type(v.value) == "table" then 
            return 3, v.value
        end
        return 3, {v.value, v.value, v.value}
    elseif v.gong then
        return 2, {v.value, v.value, v.value}
    else
        return 1, {v.value}
    end
end

local function show_extra(transform, extra)
    local extra_cards = UI.Children(transform)
    for _, data in ipairs(extra or {}) do
        local type, data_tbl = get_extra_type(data)
        local cards = Instantiate(extra_cards[type]).transform
        cards:SetParent(transform, false)
        UI.Active(cards, true)
        
        local card_tbl = UI.Children(cards)
        for i, value in ipairs(data_tbl) do
            UI.Sprite(card_tbl[i], "light", sprite_name(value))
        end
    end
end


local DA_HU = {
    "碰碰胡",
    "将将胡",
    "清一色",
    "海底捞月",
    "海底炮", 
    "七小对", 
    "豪华七小对",
    "双豪华七小对",
    "三豪华七小对",
    "杠上开花",
    "杠上炮",
    "全求人",
    "抢杠胡"
}

local function format_hu(hu_ret)
    if not hu_ret then
        return ""
    end
    
    local _, detail = unpack(hu_ret)
    if not detail then
        return "平胡"
    end
    
    local desc = {}
    for _, id in ipairs(detail) do
        table.insert(desc, DA_HU[id])
    end
    return table.concat(desc, " ")
end

local QISHOU = {
    "大四喜",
    "六六顺",
    "三同",
    "节节高",
    "板板胡",
    "缺一色",
    "一枝花"
}
local function format_qishouhu(tbl)
    if table.is_empty(tbl) then
        return ""
    end
    
    local desc = {}
    for id, count in pairs(tbl) do
        table.insert(desc, QISHOU[id] .. "x" .. count)
    end
    return table.concat(desc, " ")
end

local function init_sound(transform)
    local audio = transform:GetComponent(AudioSource)
    return function(name)
        local clip = UI.LoadAudio("zzmj/" .. name)
        audio.clip = clip
        audio.volume = UI.GetVolume()
        audio:Play()
    end
end

local function show_horse(transform, data_horse)
    -- local horse_count = 0
    -- for _, value in ipairs(data_horse) do
    --     value = value % 9 + 1
    --     local check = value == 1 or value == 5 or value == 9
    --     if check then
    --         horse_count = horse_count + 1
    --     end
    -- end
    
    UI.Active(transform, not table.is_empty(data_horse))
    local horse_tbl = UI.Children(transform:Find("cards"))
    for j, value in ipairs(data_horse) do
        local horse_trans = horse_tbl[j]
        UI.Active(horse_trans, true)
        UI.Sprite(horse_trans, "light", sprite_name(value))
        -- value = value % 9 + 1
        -- local check = value == 1 or value == 5 or value == 9
        -- UI.Active(horse_trans:Find("check"), check)
    end
end

return function(player_id, room_data, result, on_close)
    local transform = UI.InitWindow("zzmj/result")
    local sound_eff = init_sound(transform)
    UI.Label(transform, "bg/words", string.format("第%d/%d局", room_data.round, room_data.max_round))
    
    show_horse(transform:Find("horse"), result.horse or {})
    
    local is_win = false
    for i, trans in ipairs(UI.Children(transform:Find("players"))) do
        local data = result[i]

        UI.Label(trans, "info/name", data.name)
        UI.Label(trans, "info/id", data.id)
        UI.Active(trans:Find("info/bg/lightFrame"), data.is_self)
        UI.Active(trans:Find("info/zhuang"), data.is_zhuang)
        UI.RoleHead(trans:Find("info/icon/head"), data.headimgurl)
        
        local is_hu = data.zimo or data.is_pao == false
        if is_hu then
            if data.zimo  then
                UI.Active(trans:Find("info/zimo"), true)
            else 
                UI.Active(trans:Find("info/hu"), true)
            end
        end
        
        UI.Active(trans:Find("info/pao"), data.is_pao == true)
        trans.name = is_hu and "0" or "1"
        
        local hu_card = trans:Find("hu_card")
        if hu_card and is_hu and data.hu_card then 
            UI.Active(hu_card, true)
            UI.Sprite(hu_card, "light", sprite_name(data.hu_card))
        end
        local horse_desc = {}
        if data.horse_tbl and #data.horse_tbl > 0 then 
            table.insert(horse_desc, "中鸟x" .. #data.horse_tbl)
        end
        UI.Label(trans, "horse", table.concat(horse_desc, " "))
        
        if data.piao_num and data.piao_num > 0 then 
            UI.Active(trans:Find("piao/"..data.piao_num), true)
        end
        
        if player_id == data.id then
            is_win = is_hu
        end

        show_extra(trans:Find("extra"), data.extra)
        
        local hu_desc = format_hu(data.hu_ret)
        
        local card_tbl = UI.Children(trans:Find("hand"))
        local need_remove = true
        for j, value in ipairs(data.hand or {}) do
            if need_remove and data.zimo and value == data.hu_card and not string.find(hu_desc, "杠上开花") then
               need_remove = false
           else 
               UI.Active(card_tbl[j], true)
               UI.Sprite(card_tbl[j], "light", sprite_name(value))
           end
        end
        
        local desc = {}
        -- if data.zimo then
        --     table.insert(desc, "自摸")
        -- end
        
        -- if data.is_pao ~= nil then
        --     table.insert(desc, data.is_pao == "放炮" or "点炮")
        -- end
        
        table.insert(desc, format_qishouhu(data.qishouhu))
        
        if (data.zhongtusixi or 0) > 0 then
            table.insert(desc, "中途四喜x" .. data.zhongtusixi)
        end
        
        -- if is_hu and horse_count > 0 then
        --     table.insert(desc, "中鸟x" .. horse_count)
        -- end
        
        table.insert(desc, hu_desc)
        
        UI.Label(trans, "desc", table.concat(desc, " "))

        -- UI.Label(trans, "score", string.format("%d %s%d = %d", data.total_score - data.add_score, data.add_score >= 0 and "+ " or "", data.add_score, data.total_score))
        --UI.Label(trans, "score", string.format(" %s%d ", data.add_score >= 0 and "+ " or "", data.add_score))
        if data.add_score == 0 then
            UI.Label(trans, "score_win", 0)
            UI.Label(trans, "score_lose", "")
        elseif data.add_score > 0 then
            UI.Label(trans, "score_win", "+"..data.add_score)
            UI.Label(trans, "score_lose", "")
        elseif data.add_score < 0 then
            UI.Label(trans, "score_lose", data.add_score)
            UI.Label(trans, "score_win", "")
        end
        
    end
    
    UI.Active(transform:Find("bg/" .. (is_win and "win" or "lose")), true)
    sound_eff(is_win and "win" or "loss")
    --play_hu(is_win)
    UI.OnClick(transform, "buttons/continue", function()
        Destroy(transform.gameObject)
        transform = nil
        on_close()
    end)
    return function()
        if transform then
            Destroy(transform.gameObject)
            transform = nil
        end
    end
end
