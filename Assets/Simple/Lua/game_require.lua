local require_api = {
    --"room_continue",
    "room_role",
    "lib.server",
    "data.msg",
    "room_bgm",
    "hint",
}

--allow from ext.lua
local ext_api = [[
table.is_empty
table.copy
table.index
table.length
table.update
table.random
table.is_same_day
table.merge
table.dump
table.remove_values
string.split
_G.check_hu
_G.UnityEngine
_G.TweenPosition
_G.UIGrid
_G.UIWidget
_G.UI2DSprite
_G.UI
_G.UIEventListener
_G.LuaTimer
_G.UITable
_G.LERR
_G.LLOG
]]

local sandbox = require "sandbox"

local open_require = {}
for _, k in ipairs(require_api) do
    open_require[k] =  sandbox.read_only(require(k), k)
end

ext_api:gsub('%S+', function(id)
    local module, method = id:match('([^%.]+)%.([^%.]+)')
    sandbox.set_env_method(module, method, _G[module][method])
end)

local game_path, game_loaded, game_reg
local function game_require(name)
    local mod = open_require[name]
    if mod then
        return mod
    end

    if string.match(name, "services%.%a+%.util") then
        open_require[name] = sandbox.read_only(require(name), name)
        return open_require[name]
    end

    mod = game_loaded[name]
    if mod then
        return mod
    end

    assert(name ~= "game_msg", "do not load " .. name .. ".lua file!")

    local path = game_path .. "/" .. name:gsub("%.", "/") .. ".lua"
    local f = loadfile(path)
    assert(f, "module '" .. path .. "' not found")
    mod = sandbox.run(f)
    game_loaded[name] = mod
    return mod
end
sandbox.set_env("require", game_require)
sandbox.set_env("MSG_REG", setmetatable({}, {
    __index = MSG_REG,
    __newindex = function(_, pt, v)
        if MSG_REG[pt] ~= nil then
            error(string.format("duplicate MSG_REG, pt: 0x%08x", pt), 2)
        end
        MSG_REG[pt] = v
        game_reg[pt] = true
    end
}))

return function(_game_name, _game_path)
    game_path = _game_path
    game_loaded = {}
    if game_reg then
        for k in pairs(game_reg) do
            MSG_REG[k] = nil
        end
    end
    game_reg = {}

    local game
    if ENABLE_SANDBOX then
        game = game_require(_game_name)
    else
        game = require(_game_name)
    end
    --game.__VERSION = game_require("__VERSION")
    return game
end
