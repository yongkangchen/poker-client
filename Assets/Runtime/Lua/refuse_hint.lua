local Destroy = UnityEngine.Object.Destroy
local NOTICE = {
    [1] = "已在其他房间开始游戏！",
    [2] = "拒绝您的邀请！",
}

local timer_id

return function(transform, refusal_tbl)
    local wait_trans
    if transform and transform.parent:Find("refuse_hint(Clone)") then
        wait_trans  = transform.parent:Find("refuse_hint(Clone)")
    else
        wait_trans = UI.InitPrefab("refuse_hint") 
    end
     
    if refusal_tbl then
        UI.Active(wait_trans:Find("host"), false)
        local count = 0
        for name, key in pairs(refusal_tbl) do
            count = count + 1
            UI.Label(wait_trans, "grid/"..count, name..NOTICE[key])
            wait_trans:Find("bg"):GetComponent(UI2DSprite).height = 60 * count
            if count == table.length(refusal_tbl) then
                if timer_id then
                    LuaTimer.Delete(timer_id)
                    timer_id = nil
                end
                timer_id = LuaTimer.Add(3000, function() 
                    Destroy(wait_trans.gameObject)
                    for _name, _key in pairs(refusal_tbl) do
                        refusal_tbl[_name] = nil
                    end
                end)
            end
        end 
    else
        timer_id = LuaTimer.Add(5000, function() 
            Destroy(wait_trans.gameObject)
            timer_id = nil
        end)
    end
end