local show_hint = require "hint"

local Destroy = UnityEngine.Object.Destroy

return function(room_data, mid_enter_room)
    local ask_data = room_data.ask_data

    local transform = UI.InitWindow("mid_enter")

    UI.Label(transform, "round_count", room_data.round_count)
    UI.Label(transform, "cash_count", room_data.need_cash)

    local count = 0
    for i = 1, 5 do
        if room_data.names[i] then
            count = count + 1
            UI.Active(transform:Find("grid/name" .. i), true)
            UI.Label(transform, "grid/name" .. i, room_data.names[i])
        else
            UI.Active(transform:Find("grid/name" .. i), false)
        end
    end
    UI.Label(transform, "player_count", count)

    UI.OnClick(transform, "close", function()
        Destroy(transform.gameObject)
    end)

    local visit_btn = transform:Find("visit")
    if visit_btn then
        local button = visit_btn:GetComponent(UIButton)
        local enable = false
        if ask_data and ask_data.can_visit then
            enable = true
        end

        if button then
            button.isEnabled = enable
        end

        UI.OnClick(visit_btn, nil, function()
            if not enable then
                show_hint("房间已满！")
                return
            end
            coroutine.wrap(function()
                mid_enter_room(room_data.room_id, nil, true)
                Destroy(transform.gameObject)
            end)()
        end)
    end

    local enable = false
    if ask_data == nil or ask_data.can_mid_enter then
        enable = true
    end

    local button = UI.GetComponent(transform, "join", UIButton)
    if button then
        button.isEnabled = enable
    end

    UI.OnClick(transform, "join", function()
        if not enable then
            show_hint("房间已满！")
            return
        end

        coroutine.wrap(function()
            mid_enter_room(room_data.room_id, true)
            Destroy(transform.gameObject)
        end)()
    end)
end
