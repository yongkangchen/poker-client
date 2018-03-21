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

local Destroy = UnityEngine.Object.Destroy

local function init_game_create(game_name, transform, parse_create)
    local select_trans = UI.InitPrefab(game_name .. "/select", transform)
    local pos = transform:Find("select_pos")
    if pos then
        select_trans.localPosition = pos.localPosition
    end

    if not select_trans:GetComponent(UITable) then
        local tb = select_trans.gameObject:AddComponent(UITable)
        tb.columns = 1
        tb.padding = UnityEngine.Vector2(0, 2)
        tb:Reposition()
    end

    local trans_select_tbl = UI.Children(select_trans)
    local trans_create_parent = UI.InitPrefab(game_name .. "/create", transform)
    local trans_panel_tbl = UI.Children(trans_create_parent)

    for i, trans_select in ipairs(trans_select_tbl) do
        local trans_panel = trans_panel_tbl[i]
        trans_select:GetComponent(UIToggledObjects).activate[0] = trans_panel.gameObject

        local toggle = trans_select:GetComponent(UIToggle)
        local function load_content()
            if not toggle.value then
                return
            end
            EventDelegate.Remove(toggle.onChange, load_content)

            local trans_create_sub = UI.InitPrefab(game_name .. "/create_" .. trans_select.name, trans_panel)
            if not trans_create_sub then
                return
            end

            for _, trans in ipairs(UI.Children(trans_create_sub)) do
                trans:SetParent(trans_panel, false)
            end
            Destroy(trans_create_sub.gameObject)
        end
        EventDelegate.Add(toggle.onChange, load_content)
    end

    if not game_cfg.IS_NEW_CREATE then
        parse_create = parse_create(function() end, transform)
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
        local parse_create = require(game_name .. ".create")
        local transform = show_create(function(close_create)
            coroutine.wrap(function()
                if create_room(game_name, nil, parse_create()) then
                    close_create()
                end
            end)()
        end)

        init_game_create(game_name, transform, parse_create)
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
