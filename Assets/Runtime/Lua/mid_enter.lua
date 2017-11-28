local Destroy = UnityEngine.Object.Destroy

return function(room_data, mid_enter_room)
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

    UI.OnClick(transform, "join", function()
        coroutine.wrap(function()
            mid_enter_room(room_data.room_id)
            Destroy(transform.gameObject)
        end)()
    end)
end
