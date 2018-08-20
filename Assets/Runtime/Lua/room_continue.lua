return function(parent, close)
    local room_continue = UI.room_continue
    if room_continue == nil then
        return
    end
    UI.room_continue = nil
    
    local transform = UI.InitPrefab("room_continue", parent)
    UI.OnClick(transform, nil, function()
        close()
        room_continue()
    end)
end