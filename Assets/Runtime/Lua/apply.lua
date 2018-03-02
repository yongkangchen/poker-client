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
local Vector3 = UnityEngine.Vector3
local server = require "lib.server"
local msg = require "data.msg"
local show_hint = require "hint"
local agree_color_tbl = {{12, 120, 165}, {191, 54, 0}, {135, 77, 46}, {28, 111, 135}}

return function(parent, exit_info, on_close)
    local transform = UI.InitWindow("apply", parent)
    local item_tbl = {}
    
    for idx, role_data in pairs(exit_info.role_tbl) do
        local role_name = role_data.name
        local is_agree = false
        local agree_str
        local is_online = true
        local online_str
        if not role_data.ip then
            is_online = false
        end
        
        local item_trans = transform:Find("grid/" .. idx)
        local function set_state()
            if is_agree then
                agree_str = "【已同意】"
                UI.LabelColorChange(item_trans, nil, unpack(agree_color_tbl[idx] or agree_color_tbl[4]))
            else
                agree_str = "【等待选择】"
                UI.LabelColorChange(item_trans, nil, unpack(agree_color_tbl[idx] or agree_color_tbl[4]))
            end
            UI.Label(item_trans, nil, UI.LimitName(role_name) .. agree_str)
            
            if not is_online then
                online_str = "离线"
                UI.LabelColorChange(item_trans:Find("online"), nil, 121, 121, 121)
            else
                online_str = "在线"
                UI.LabelColorChange(item_trans:Find("online"), nil, 5, 143, 21)
            end
            UI.Label(item_trans:Find("online"), nil, online_str)
            
            local online_position_x = item_trans:GetComponent(UIWidget).width + 10
            item_trans:Find("online").localPosition = Vector3(online_position_x, 0, 0)
        end
    
        UI.Active(item_trans, true)

        item_tbl[role_data.id] = {
            name = role_name,
            set_agree = function()
                is_agree = true
                set_state()
            end,
            set_wait = function()
                if is_agree then
                    return
                end
                set_state()
            end,
            set_online = function(online)
                is_online = online
                set_state()
            end,
            hide = function()
                UI.Active(item_trans, false)
            end,
        }
    end
    for idx, role_id in pairs(exit_info.dismiss_tbl) do
        if idx == 1 then
            item_tbl[role_id].hide()
            UI.Label(transform, "name", "玩家" .. item_tbl[role_id].name .. "申请解散房间")
        else
            item_tbl[role_id].set_agree()
        end
    end
    
    local function disable_button()
        UI.GetComponent(transform, "ok", UIButton).isEnabled = false
        UI.GetComponent(transform, "cancel", UIButton).isEnabled = false
    end
    
    UI.OnClick(transform, "ok", function()
        disable_button()
        server.agree(true)
    end)
    
    UI.OnClick(transform, "cancel", function()
        server.agree(false)
    end)    
    
    server.listen(msg.AGREE, function(ret, role_id, is_close)
        if ret then
            item_tbl[role_id].set_agree()
            if is_close then
                Destroy(transform.gameObject)
                on_close()
            end
        else
            show_hint(item_tbl[role_id].name .. "拒绝了解散房间")
            Destroy(transform.gameObject)
        end
    end)
    
    if table.index(exit_info.dismiss_tbl, exit_info.player_id) then 
        disable_button()
    end

    local end_time = os.time() + exit_info.dismiss_time
    local timer_id = LuaTimer.Add(0, 1000, function()
        local count = end_time - os.time()
        if count >= 0 then
            for _, item in pairs(item_tbl) do
                item.set_wait(count)
            end
            UI.Label(transform, "time/timer", count)
            return true
        else
            return false
        end
    end)
    
    UI.OnDestroy(transform, function()
        LuaTimer.Delete(timer_id)
        transform = nil
    end)
    
    return function(id, is_online)
        if transform == nil then
            return
        end
        item_tbl[id].set_online(is_online)
    end,
    function()
        Destroy(transform.gameObject)
    end
end
