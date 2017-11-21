--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local game_cfg = require "game_cfg"
local TYPE_NAME = game_cfg.GAME and (require "zzmj.game_cfg").TYPE_NAME or game_cfg.TYPE_NAME
local server = require "lib.server"
local check_hu = require "zzmj.hu"

local msg = require "data.msg"

local show_result = require "zzmj.result"
local show_over = require "zzmj.over"
local create_role = require "zzmj.role"
local init_out_time = require "zzmj.out_time"

local show_bird = require "zzmj.bird"
local room_bgm = require "room_bgm"

local function init_select(transform)
    local btn_parent = transform:Find("buttons")
    local grid = btn_parent:GetComponent(UIGrid)

    local dict = {}
    local function hide_all()
        UI.Active(transform, false)
        for _, set_btn in pairs(dict) do
            set_btn()
        end
    end

    for _, btn in ipairs(UI.Children(btn_parent)) do
        local on_click
        UI.OnClick(btn, nil, function()
            if not on_click then
                return
            end

            on_click()
            hide_all()
        end)

        dict[btn.name] = function(_on_click)
            on_click = _on_click
            UI.Active(btn, on_click ~= nil)
        end
    end

    local function default_cancel() end
    return function(name, on_ok, on_cancel)
        UI.Active(transform, true)

        dict[name](on_ok)
        dict.guo(on_cancel or default_cancel)
        grid.repositionNow = true
    end, hide_all
end

local function init_data(data)
    data.out = data.out or {}
    data.extra = data.extra or {}
    data.score = data.score or 0
    return data
end

local function remove_hand(data, card, num)
    num = num or 1

    local hand = data.hand
    local idx
    if type(hand) == "table" then
        table.remove_values(hand, card, num)
        idx = #data.hand
    else
        hand = hand - num
        data.hand = hand
        idx = hand
    end
    return idx
end

return function(player_info, parent, close_room)
    local room_data = player_info.room_data
    local player_id = player_info.id
    
    room_data.type_name = TYPE_NAME
    
    local transform = UI.InitPrefab("zzmj/zzmj", parent)
    -- room_id, num, horse
    UI.Label(transform, "desk/info/id", string.format("房号: %d", room_data.id))
    UI.Label(transform, "desk/info/horse", string.format("抓%s个鸟", room_data.horse))
    UI.Label(transform, "desk/info/roomclass", room_data.type_name)
    UI.Label(transform, "desk/info/round", string.format("第%d/%d局", room_data.round, room_data.max_round))
    
    local card_num = 108
    local function set_card_num(add)
        card_num = card_num + (add or 0)
        UI.Label(transform, "desk/info/count", string.format("剩%d张", card_num))
        -- UI.Label(transform, "desk/info/count", string.format("第%d/%d局", room_data.round, room_data.max_round))
    end
    set_card_num()
    
    local role_tbl = {}
    local player_data = table.copy(player_info)
    
    local player = create_role(
        transform:Find("player/0"), player_data, function(card)
            local role = role_tbl[player_id]
            local data = role.data
            if not data.can_out then
                return
            end
            
            server.zz_out(table.index(data.hand, card), card)
            data.can_out = false
            role.set_now_out(card)
            role.out_flag(false)
            return true
        end)
        
    player.data = init_data(player_data)
    role_tbl[player_id] = player
    
    local show_select, hide_all = init_select(transform:Find("select"))
    
    local function check_out()
        local data = player.data
        local hand = data.hand
        
        if data.new_idx then
            local ret = check_hu(hand, room_data.seven_hu)    
            if ret then
                player.out_flag(true, true)
                if room_data.qiangzhi_hu then
                    LuaTimer.Add(1000, function()
                        server.zz_hu()
                    end)                                       
                else
                    show_select("hu", function()
                        server.zz_hu()
                    end,function()
                        player.out_flag(true, false)  
                    end)
               end
            end
        end
        
        local dict = {}
        for _, value in ipairs(hand) do
            local count = (dict[value] or 0) + 1
            if count == 4 then
                player.out_flag(true, true)
                show_select("angang", function()
                    server.zz_out_gang(value)
                end,function()
                    player.out_flag(true, false) 
                end)
                return
            end
            dict[value] = count
        end

        for _, v in ipairs(data.extra) do
            if v.num == 3 and v.value == hand[data.new_idx] then
                player.out_flag(true, true)
                show_select("gang", function()
                    server.zz_peng_gang(v.value)
                end,function()
                    player.out_flag(true, false)  
                end)
                return
            end
        end
    end
    
    local show_out_time = init_out_time(transform)

    server.listen(msg.START, function(hand, zhuang_id)
        room_bgm("bgm_dapai64")
        player.show_eff("kaishi/words")
        server.sleep(1250)
        LuaTimer.Add(1200, function()
            for id, role in pairs(role_tbl) do
                local data = role.data
                data.is_zhuang = id == zhuang_id
                data.new_idx = data.is_zhuang and 14 or nil
                
                if role == player then
                    data.hand = hand
                else
                    data.hand = data.is_zhuang and 14 or 13
                end
                
                role.zhuang(data.is_zhuang)
                role.score(data.score)
                role.show_hand(data.hand, data.new_idx)
            end
            set_card_num(-13 * 4 - 1)
        end)
    end)
    
    server.listen(msg.START_OUT, function(zhuang_id)
        local role = role_tbl[zhuang_id]
        local data = role.data
        data.can_out = true
        role.out_flag(true)
        show_out_time()
        role.zhuang(true)
        if role == player then
            check_out()
        end
    end)

    server.listen(msg.ADD, function(id, card, card_idx)
        local role = role_tbl[id]
        local data = role.data

        if type(data.hand) == "table" then
            table.insert(data.hand, card_idx, card)
        else
            data.hand = data.hand + 1
            card_idx = data.hand
        end
        data.new_idx = card_idx
        role.show_hand(data.hand, card_idx)

        data.can_out = true
        role.out_flag(true)
        if role == player then
            check_out()
        end
        
        set_card_num(-1)
    end)
    
    local pre_out_role
    local function hide_pointer()
        if pre_out_role then
            pre_out_role.hide_pointer()
            pre_out_role = nil
        end
    end
    
    local function show_now_out()
        if pre_out_role then
            pre_out_role.now_out(true)
        end
    end
    
    server.listen(msg.OUT, function(id, card)
        hide_pointer()
        
        local role = role_tbl[id]
        local data = role.data
        if role == player then 
            hide_all()
        end
        remove_hand(data, card)
        
        table.insert(data.out, card)
        role.show_out(data.out, card, nil, data.sex)
        
        data.new_idx = nil
        role.show_hand(data.hand, data.new_idx)
        
        data.can_out = false
        role.out_flag(false)
        pre_out_role = role
        show_out_time()
    end)

    server.listen(msg.SELECT, function(name)
        show_now_out(true)
        if room_data.qiangzhi_hu and name == "hu" then
            LuaTimer.Add(1000, function()
                server.zz_hu(true)
                show_now_out(false)
            end)
        else  
            show_select(name, function()
                server["zz_" .. name](true)
                show_now_out(false)
            end, function()
                server["zz_" .. name](false)
                show_now_out(false)
            end)
        end    
    end)


    server.listen(msg.PENG, function(to_id, from_id)
        local role = role_tbl[from_id]

        local out = role.data.out
        local card = table.remove(out)
        role.show_out(out)
        hide_pointer()

        role = role_tbl[to_id]

        local data = role.data

        remove_hand(data, card, 2)

        role.show_hand(data.hand)
        role.add_peng(card, nil , data.sex)

        if role == player then
            table.insert(data.extra, {value = card, num = 3})
        end

        data.can_out = true
        role.out_flag(true)
        
        if role == player then
            check_out()
        end
    end)

    server.listen(msg.GANG, function(to_id, from_id)
        local role = role_tbl[from_id]

        local out = role.data.out
        local card = table.remove(out)
        role.show_out(out)
        hide_pointer()

        role = role_tbl[to_id]
        local data = role.data

        remove_hand(data, card, 3)
        role.show_hand(data.hand, data.new_idx)

        role.add_gang(card)
    end)

    server.listen(msg.OUT_GANG, function(id, card)
        local role = role_tbl[id]
        local data = role.data

        remove_hand(data, card, 4)
        role.show_hand(data.hand, data.new_idx)
        role.add_an_gang(card, nil, data.sex)
    end)

    server.listen(msg.PENG_GANG, function(id, card)
        local role = role_tbl[id]
        local data = role.data
        remove_hand(data, card, 1)
        data.can_out = false
        role.show_hand(data.hand, nil)
        role.remove_peng(card)
        role.add_gang(card, nil, data.sex)
    end)
    room_bgm("bgm_fangjian64")
    
    local function init_role(data)
        local role = role_tbl[data.id]
        if not role then
            role = create_role(transform:Find("player/" .. data.distance), data)
            role_tbl[data.id] = role
        end
        
        role.data = init_data(data)
        if data.hand then
            local idx, count
            if type(data.hand) == "table" then
                count = #data.hand
                idx = data.new_idx or count
            else
                count = data.hand
                idx = count
            end
            set_card_num(-count-(#data.out))
            
            role.show_hand(data.hand, data.can_out and idx or nil)
            for _, v in ipairs(data.extra) do
                if v.num == 3 then
                    role.add_peng(v.value, true)
                elseif v.gong then
                    role.add_gang(v.value, true)
                else
                    role.add_an_gang(v.value, true)
                end
                set_card_num(-v.num)
            end
            if data.pre_out_role then 
                pre_out_role = role
                role.show_out(data.out, data.out[#data.out], true)
            else 
                role.show_out(data.out)
            end
            role.out_flag(data.can_out)
            if data.can_out then 
                show_out_time()
            end
        end

        if data.is_zhuang then
            role.zhuang(true)
        else
            role.zhuang(false)
        end

        if data.id == player_id then
            player = role
            if data.can_out then
                check_out()
            end
        end
        return role
    end

    server.listen(msg.RESULT, function(result, is_over)
        local time = 10
        local horse_tbl = {}
        local winner
        local winner_zimo = false
        for _, role in ipairs(result) do 
        	if role.zimo or role.is_pao == false then 
                if role.zimo then
                    winner_zimo = true
                    role_tbl[role.id].show_eff("win_zimo/words")
                else
                    role_tbl[role.id].show_eff("hu/words")
                end
                time = 1000
                winner = role_tbl[role.id]
        	end	
            if role.horse_tbl then
                horse_tbl[role_tbl[role.id].data.distance] = role.horse_tbl
            end 
        end
        if winner then 
            player.play_hu(winner.data.sex, winner_zimo)
        end
        
        if not table.is_empty(result.horse) then
            LuaTimer.Add(time, function()
                LERR("transform:Find(zzmj(Clone)):",transform:Find("zzmj(Clone)"))
                show_bird(result.horse, horse_tbl, transform)
            end)
            time = time + 1500
            if not table.is_empty(horse_tbl) then 
                time = time + 1000
            end
        end
        
        local on_close
        UI.OnDestroy(transform, function()
            on_close()
        end)
        
        local timer_id = LuaTimer.Add(time, function()
            on_close = show_result(player_id, room_data, result, coroutine.wrap(function()
                if is_over then
                    sync(show_over)(result, player_data)
                end
                close_room(is_over)
            end))
        end)
        
        on_close = function()
            LuaTimer.Delete(timer_id)
        end
    end)
    return init_role, role_tbl
end
