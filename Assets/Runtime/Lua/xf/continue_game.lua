
local Destroy = UnityEngine.Object.Destroy
local server = require "lib.server"
local msg = require "data.msg"
local show_hint = require "hint"

return function(player_data, room_id, create_time, close)
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

    local end_count = create_time + 60
    timer_id = LuaTimer.Add(0, 1000, function() 
        local count = end_count - os.time()
        if count == 0 then
            close_func()
        end
        UI.Label(transform,"tip/time", count.."s")
    end)
    
    UI.OnClick(transform, "sure", function()
         game.enter(room_id)
         server.comfirm_msg(msg.ROOM_INVITE, true, room_id, create_time)
          close_func()
    end)    
    
    UI.OnClick(transform, "no", function ()
        server.comfirm_msg(msg.ROOM_INVITE, false, room_id, create_time)
        close_func()
    end)
end
