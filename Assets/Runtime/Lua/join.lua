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

local server = require "lib.server"
local show_hint = require "hint"
local show_bound_tip = require "pk.tip"
local show_buy = require "buy"

local JOIN_ERROR = {
    [1] = "赛事码输入有误",
    [2] = "已经加入过此比赛",
    [3] = "内部比赛，不能参加",
    [4] = "你尚未绑定代理ID",
}

return function(do_enter, player_data)
    local transform = UI.InitWindow("join")
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
    end)

    local input = UI.Children(transform:Find("input"))
    local tip
    if player_data then
        UI.Active(transform:Find("bg/title"), false)
        UI.Active(transform:Find("bg/title_pk"), true)
        UI.Active(transform:Find("paste"), true)
        UI.Active(transform:Find("input/tip", false))
        tip = transform:Find("input/tip_pk")
        UI.Active(tip, true)
    else
        tip = transform:Find("input/tip")
    end

    local idx = 0
    local num = 0

    local function delete()
        local v = input[idx]
        if not v then
            return
        end
        num = num - num % (10^(7-idx))
        UI.Sprite(v, "num", nil)
        idx = idx - 1
        if idx == 0 and tip then
            UI.Active(tip, true)
        end
    end

    local function clear()
        for _ = 1, idx do
            delete()
        end
        if tip then
            UI.Active(tip, true)
        end
    end

    local function join_match()
        coroutine.wrap(function()
            local info, error_num = server:pk_join(num)
            if tonumber(error_num) == 4 then
                info.player_data = player_data
                delete()
                show_bound_tip(function()
                    Destroy(transform.gameObject)
                    show_buy(player_data, function() end)
                end, info, 6)
            elseif info then
                do_enter(info)
                Destroy(transform.gameObject)
            else
                delete()
                show_hint(JOIN_ERROR[error_num])
            end
        end)()
    end

    local function do_join()
        if player_data then
            join_match()
        else
            do_enter(num, function(ok)
                if ok then
                    Destroy(transform.gameObject)
                else
                    delete()
                end
            end)
        end
    end

    if player_data then
    -- 粘贴邀请码
    local paste_value = UI.GetComponent(transform, "temp", UIInput)
        UI.OnClick(transform, "paste", function()
            -- 手机粘贴板
            if BDLocationUtil == nil then
                require "app_upgrade"("app需要更新才能粘贴文字")
            else
                local text = Util.clipboardGetText()
                if text == nil then
                    LLOG("nil text")
                else
                    LLOG("clipboardGetText:%s", text)
                    paste_value.value = text
                end
            end
            -- paste_value.value = "小幺756841668335哈哈"
            local num = tonumber(paste_value.value)
            if num < 0 then
                return
            end
            LERR("@@@@@@@@@@@ paste_value:%s", num)
            UI.Active(tip, false)
            local num_str = tostring(num)
            idx = 0
            for i = 1, #num_str do
                idx = idx + 1
                local num_sub = string.sub(num_str, i, i)
                -- LERR("%s = %s", i, num_sub)
                UI.Sprite(input[idx], "num", "light_num_" .. num_sub)
                if input[idx + 1] == nil then
                    break
                end
            end
            if idx ~= 6 then
                return
            end
            do_join()
        end)
    end

    for i = 0, 9 do
        UI.OnClick(transform, "keyboard/" .. i, function()
            if input[idx + 1] == nil then
                return
            end

            idx = idx + 1
            num = num + (10^(6 - idx)) * i
            UI.Sprite(input[idx], "num", "light_num_" .. i)

            if tip then
                UI.Active(tip, false)
            end

            if idx ~= 6 then
                return
            end

            do_join()
        end)
    end

    UI.OnClick(transform, "keyboard/del", delete)
    UI.OnClick(transform, "keyboard/clear", clear)
end
