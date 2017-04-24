--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

return function(total_horse, horse_tbl, parent)
    local transform = UI.InitPrefab("zzmj/horse", parent)
    UI.Active(transform:Find("all_horse"), true)
    local card_tbl = UI.Children(transform:Find("all_horse/cards"))
    for i, value in ipairs(total_horse) do 
        local horse_tran = card_tbl[i]
        UI.Active(horse_tran, true)
        UI.Sprite(horse_tran, "light", "tile_me_" .. value)
    end
    if table.is_empty(horse_tbl) then 
        return
    end
    for i, horse in pairs(horse_tbl) do
        local trans_tbl = UI.Children(transform:Find(i.."/cards"))
        for j, value in ipairs(horse) do 
            local horse_tran = trans_tbl[j]
            UI.Active(horse_tran, true)
            UI.Sprite(horse_tran, "light", "tile_me_" .. value)
        end
        transform:Find(i.."/cards"):GetComponent(UIGrid).repositionNow = true
    end
    LuaTimer.Add(1000, function()
        UI.Active(transform:Find("all_horse"), false)
        for i in pairs(horse_tbl) do 
            UI.Active(transform:Find(i..""), true)
        end
    end)
    return
end
