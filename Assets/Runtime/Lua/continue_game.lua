
local Destroy = UnityEngine.Object.Destroy
local server = require "lib.server"
local msg = require "data.msg"
local show_hint = require "hint"

return function(player_data, organizer_id, room_id, end_time, close)
    local game = require "game"
    local transform = UI.InitPrefab("invite_hint")
    local over_trans = transform.parent:Find("over(Clone)")
    local result_trans = transform.parent:Find("result(Clone)")
    local timer_id
    
    local delete_func = function()
        if timer_id then 
            LuaTimer.Delete(timer_id)
            timer_id = nil
        end
        Destroy(transform.gameObject)
    end
    
    local function close_func()
        if over_trans then
            Destroy(over_trans.gameObject)
        end
        if result_trans then
            Destroy(result_trans.gameObject)
        end
        if player_data and player_data.room_data then
            close(true)
        end
        delete_func()
    end

    local end_count = os.time() + end_time
    timer_id = LuaTimer.Add(0, 1000, function() 
        local count = end_count - os.time()
        if count == 0 then
            close_func()
        end
        UI.Label(transform,"tip/time", count.."s")
    end)
    
    UI.OnClick(transform, "sure", function()
        server.agree_invite(organizer_id, room_id)
    end)
    
    server.listen(msg.AGREE_INVITE, function(is_dismiss)
        if not is_dismiss then
            game.enter(room_id)
            close_func()
        else
            show_hint("房间已经被解散！", 1)
            delete_func()
        end
    end)
    
    UI.OnClick(transform, "no", function ()
        server.refuse_invite(organizer_id, room_id)
        close_func()
    end)

end
