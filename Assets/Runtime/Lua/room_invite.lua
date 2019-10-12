local Destroy = UnityEngine.Object.Destroy

return function(expired_time, on_close)
    if expired_time <= os.time() then
        return
    end

    local transform = UI.InitPrefab("room_invite")
    if not transform then
        return
    end

    local timer_id
    local function close_func(v)
        Destroy(transform.gameObject)
        if v ~= nil then
            on_close(v)
        end
        LuaTimer.Delete(timer_id)
    end

    timer_id = LuaTimer.Add(0, 1000, function()
        local count = expired_time - os.time()
        if count <= 0 then
            close_func()
            return false
        else
            UI.Label(transform,"tip/time", count .. "s")
            return true
        end
    end)

    UI.OnClick(transform, "sure", function()
        close_func(true)
    end)

    UI.OnClick(transform, "no", function ()
        close_func(false)
    end)
end
