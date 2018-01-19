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

local function init_game_create(game_name, transform)
    local panel_tbl = UI.Children(UI.InitPrefab(game_name .. "/create", transform))

    local select_tbl = UI.Children(UI.InitPrefab(game_name .. "/select", transform))

    for i, select in ipairs(select_tbl) do
        select:GetComponent(UIToggledObjects).activate[0] = panel_tbl[i].gameObject
    end
end

local function init(parent, enter_room, create_room)
    local game_name = game_cfg.NAME

    local trans = UI.InitPrefab(game_name .. "/game", parent)
    if trans == nil then
        trans = UI.InitPrefab("small_game", parent)
    end

    local join_btn = trans:Find("join")

    UI.OnClick(join_btn, nil, function()
        show_join(function(room_id, on_join)
            coroutine.wrap(function()
                on_join(enter_room(room_id))
            end)()
        end)
    end)

    UI.OnClick(trans:Find("create"), nil, function()
        local transform = show_create(function(close_create)
            coroutine.wrap(function()
                local parse_create = require(game_name .. ".create")
                if create_room(game_name, nil, parse_create()) then
                    close_create()
                end
            end)()
        end)
        init_game_create(game_name, transform)
    end)
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
}
