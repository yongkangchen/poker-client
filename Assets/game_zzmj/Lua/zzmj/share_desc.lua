local PLAYER_TYPES = {
    santong = "三同",
    zhong_tu_sixi = "中途四喜",
    jiejiegao = "节节高",
    yizhihua = "一枝花",
}

local HORSE_TYPE = {
    [1] = "1鸟1分",
    [2] = "加法",
    [3] = "乘法"
}

return function(room_data)
    local tbl = {room_data.player_size .. "人麻将"}
    table.insert(tbl, room_data.max_round .. "局")
    if room_data.zhuang_xian ~= nil then 
        table.insert(tbl, (room_data.zhuang_xian and "庄闲模式" or "胡牌为庄"))
    end
    
    if room_data.is_piao ~= nil then 
        table.insert(tbl, (room_data.is_piao and "可飘" or "不可飘"))
    end
    
    if room_data.kai_gang_num then 
        table.insert(tbl, "杠" .. room_data.kai_gang_num)
    end
    
    if room_data.can_pao ~= nil then 
        table.insert(tbl, room_data.can_pao and "可接炮" or "不可接炮")
    end
    
    if room_data.qiangzhi_hu ~= nil then 
        table.insert(tbl, room_data.qiangzhi_hu and "强制胡牌" or "不强制胡牌")
    end
    
    if room_data.type_name == "红中麻将" and room_data.qianggang_hu ~= nil then 
        table.insert(tbl, room_data.qianggang_hu and "允许抢杠胡" or "不允许抢杠胡")
    end
    
    if room_data.horse then
        table.insert(tbl, (room_data.horse == 0 and "不抓鸟" or "抓"..room_data.horse.."鸟"))
        if room_data.horse_type and room_data.horse > 0 then 
            table.insert(tbl, HORSE_TYPE[room_data.horse_type])
        end
    end
    
    local desc = table.concat(tbl, "、")
    
    if room_data.play_types then
        local play_tbl = {}
        for type, name in pairs(PLAYER_TYPES) do
            if room_data.play_types[type] then 
                table.insert(play_tbl, name)
            end
        end
        if not table.is_empty(play_tbl) then 
            desc = desc .. "，个性玩法: " .. table.concat(play_tbl, "、")
        end
    end
    
    if room_data.seven_hu then 
        desc = desc.."，个性玩法：七小对"
    end
    
    room_data.share_desc = desc
end
