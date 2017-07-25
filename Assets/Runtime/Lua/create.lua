--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local PlayerPrefs = UnityEngine.PlayerPrefs
local Destroy = UnityEngine.Object.Destroy

local function get_toggle_tbl(select_tbl)    
    if not select_tbl then
        return
    end
    local create_ob    
    local toggle_tbl = {} 
    for i = 1, select_tbl.Length do        
        if select_tbl[i].value then            
            table.insert(toggle_tbl, select_tbl[i]:GetComponent(UISavedOption).keyName)            
            create_ob = select_tbl[i]:GetComponent(UIToggledObjects).activate[0]        
        end    
    end    

    local tbl = create_ob.transform:GetComponentsInChildren(UIToggle, true)    
    for i = 1, tbl.Length do
        if tbl[i].value and tbl[i]:GetComponent(UISavedOption) then            
            table.insert(toggle_tbl, tbl[i]:GetComponent(UISavedOption).keyName)        
        end    
    end    
    return toggle_tbl
end

return function(controller, get_create, cost_base, be_accredit, init_create, game_name, sub_name)
    local is_appstore = require "game_cfg".APPSTORE
    local transform = UI.InitWindowX("create")
    UI.ShowType(transform, "create_coin/icon")
    UI.ShowType(transform, "create_cash/icon")

    local _, toggle_tbl = get_create(game_name, transform)
    
    local create_coin = transform:Find("create_coin")
    local create_cash = transform:Find("create_cash")
    local function is_aa()
        local type_toggle = UIToggle.GetActiveToggle(100)
        if type_toggle == nil then
            return
        end
        
        local room_type = type_toggle.transform.name
        return PlayerPrefs.GetInt(room_type .. "_opentype2", 1) == 1
    end
    
    local function set_number(n)    
        local cash_num = n * (is_aa() and 1 or cost_base)
        local coin_num = cash_num * 10
        local is_free = controller.is_free
        if is_free == nil then
            is_free = true
        else
            is_free = is_free[game_name]
        end
        UI.Label(create_coin, "money", is_free and "免费" or coin_num)
        UI.Label(create_cash, "money", is_free and "免费" or cash_num)
        
        if not is_free then
            UI.Active(create_coin:Find("mask"), controller.get_coin_num() < coin_num)
            UI.Active(create_cash:Find("mask"), controller.get_cash_num() < cash_num)
        end
        
        if not be_accredit and not is_appstore then
            UI.Active(transform:Find("buy"), controller.get_cash_num() < cash_num)
        end
    end
    
    local get_create_info = init_create(set_number, transform, sub_name)
    
    local function on_create(money_type)
        coroutine.wrap(function()
            local create_tbl = {
                money_type = money_type,
                toggle_tbl = get_toggle_tbl(toggle_tbl),
                cost_all = is_aa(),
            }
            if not controller.create(game_name, create_tbl, get_create_info()) then
                return
            end
            Destroy(transform.gameObject)
        end)()
    end
    
    UI.OnClick(transform, "back", function()
        Destroy(transform.gameObject)
    end)
    
    UI.OnClick(transform, "buy", function()
        Destroy(transform.gameObject)
        controller.buy()
    end)
    
    UI.OnClick(create_coin, nil, function()
        on_create(false)
    end)
    UI.OnClick(create_cash, nil, function()
        on_create(true)
    end)
    
    local create_accredit = transform:Find("create_accredit")
    local function accredit_ui()
        LuaTimer.Add(100, function()
            UI.Active(create_accredit, be_accredit and not is_aa())
        end)
    end
    
    if is_appstore then
        UI.Active(create_cash, false)
        UI.Active(create_coin, false)
        UI.Active(create_accredit, false)
        UI.Active(transform:Find("create_store"), true)
        UI.OnClick(transform, "create_store", function()
            on_create(false)
        end)
    end
    
    if be_accredit then
        accredit_ui()
        UI.OnClick(create_accredit, nil, function()
            on_create(3)
        end)
    end
    
    local select_tbl = UI.Children(transform:Find("select(Clone)"))
    for _, select in ipairs(select_tbl) do
        EventDelegate.Add(select:GetComponent(UIToggle).onChange, accredit_ui)
        if game_name == "mj" or game_name == "pdk" then
            EventDelegate.Add(transform:Find("create(Clone)/" .. select.name .. "/open_type/2/toggle"):GetComponent(UIToggle).onChange, accredit_ui)
            EventDelegate.Add(transform:Find("create(Clone)/" .. select.name .. "/open_type/2/toggle"):GetComponent(UIToggle).onChange, function()
                LuaTimer.Add(100, function()
                    local game = require "game"
                    local cfg = game.get_cfg(game_name)
                    set_number(PlayerPrefs.GetInt(UIToggle.GetActiveToggle(100).transform.name .. "_number" .. cfg.BASE_ROUND, 1) == 1 and 1 or 2)
                end)
            end)
        end
    end
end