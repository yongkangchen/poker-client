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
return function(do_enter, title, text, on_close, size)
    size = size or 6
    local transform = UI.InitWindow("join")
    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
        if on_close then
            on_close()
        end
    end)

    local input = UI.Children(transform:Find("input"))
    local tip = transform:Find("input/tip")

    local idx = 0
    local num = 0

    local function delete()
        local v = input[idx]
        if not v then
            return
        end
        num = num - num % (10^(size + 1 - idx))
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

    for i = 0, 9 do
        UI.OnClick(transform, "keyboard/" .. i, function()
            if input[idx + 1] == nil then
                return
            end

            idx = idx + 1
            num = num + (10^(size - idx)) * i
            LERR("num: %s", num)
            UI.Sprite(input[idx], "num", "light_num_" .. i)

            if tip then
                UI.Active(tip, false)
            end

            if idx ~= size then
                return
            end

            do_enter(num, function(ok)
                if ok then
                    Destroy(transform.gameObject)
                else
                    delete()
                end
            end)
        end)
    end

    UI.OnClick(transform, "keyboard/del", delete)
    UI.OnClick(transform, "keyboard/clear", clear)

    if title then
        local title_trans = transform:Find("bg/" .. title)
        if title_trans then
            UI.Active(title_trans, not UI.Active(transform:Find("bg/title"), false))
        end
    end

    if text then
        local text_tbl = tip:GetComponentsInChildren(UILabel, true)
        for i = 1, text_tbl.Length do
            local lab = text_tbl[i]
            lab.text = string.sub(text, i, i)
        end
    end
end
