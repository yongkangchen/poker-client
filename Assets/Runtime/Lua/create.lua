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

return function(controller, get_create, cost_base, be_accredit, init_create, game_name, sub_name)
    local transform = UI.InitWindow("create")
    UI.ShowType(transform, "create_coin/icon")
    UI.ShowType(transform, "create_cash/icon")

    get_create(game_name, transform)
    
    local create_coin = transform:Find("create_coin")
    local create_cash = transform:Find("create_cash")
    
    local function set_number(n)    
        local cash_num = n * cost_base
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
    
        if not be_accredit then
            UI.Active(transform:Find("buy"), controller.get_cash_num() < cash_num)
        end
    end
    
    local get_create_info = init_create(set_number, transform, sub_name)
    
    local function on_create(money_type)
        coroutine.wrap(function()
            if not controller.create(game_name, money_type, get_create_info()) then
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
    UI.Active(create_accredit, be_accredit)
    UI.OnClick(create_accredit, nil, function()
        on_create(3)
    end)
end
