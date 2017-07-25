--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local show_join = require "join"
local show_create = require "create"

local game_cfg = require "game_cfg"

local function init_select(game_name, transform)
    local select_trans = UI.InitPrefabX(game_name .. "/select", transform)
    local select_tbl = UI.Children(select_trans) 
    select_trans.localPosition = UnityEngine.Vector3(-554, 257)
    
    if not select_trans:GetComponent(UITable) then
        local tb = select_trans.gameObject:AddComponent(UITable)
        tb.columns = 1
        tb.padding = UnityEngine.Vector2(0, 2)
    end
    return select_tbl
end

local function get_create(game_name, transform)
    local select_tbl = init_select(game_name, transform)  
    local panel_tbl = UI.Children(UI.InitPrefabX(game_name .. "/create", transform))
    
    for i, select in ipairs(select_tbl) do
        select:GetComponent(UIToggledObjects).activate[0] = panel_tbl[i].gameObject
    end
    return select_tbl
end

local function init(parent, lobby_controller)
    UI.InitPrefabX(game_cfg.NAME .. "/title", parent)
    
    local trans = UI.InitPrefabX(game_cfg.NAME .. "/game", parent)
    local join_btn = trans:Find("join")
    
    UI.OnClick(join_btn, nil, function()
        show_join(lobby_controller.enter)
    end)
    
    UI.OnClick(trans:Find("create"), nil, function()
        coroutine.wrap(function()
            local game_name = game_cfg.NAME
            
            local init_create = require(game_name .. ".create")
            show_create(lobby_controller, get_create, 3, nil, init_create, game_name)
        end)()
    end)
end

local function InitPrefabGame(_, path, parent, is_x)
    if is_x then
        return UI.InitPrefabX(path, parent)
    end

    return  UI.InitPrefab(path, parent)
end

local function InitWindowGame(_, path, parent, is_x)
    if is_x then
        return UI.InitWindowX(path, parent)
    end

    return  UI.InitWindow(path, parent)
end

return {
    play = function()
        local init_room = require "room"    
        return function(player_data, on_over)
            local game_name = player_data.room_data.game_name
            local play = require(game_name .. "." .. game_name)
            return init_room(play, player_data, on_over)
        end
    end,
    init = init,
    get_create = get_create,
    get_cfg = function()
        return game_cfg
    end,
    InitPrefabGame = InitPrefabGame,
    InitWindowGame = InitWindowGame,
}
