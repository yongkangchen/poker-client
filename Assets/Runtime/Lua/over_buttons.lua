local show_hint = require "hint"
local upgrade = require "app_upgrade"
local game = require "game"

local Destroy = UnityEngine.Object.Destroy

local function copy_result(result, data)
    if not result then
        return
    end
    
    if BDLocationUtil == nil then
        upgrade("app需要更新才能复制战绩")
        return
    end

    local time = os.date("%Y-%m-%d %H:%M", data.time)
    data.type_name = data.type_name or game.get_type_name(data.game_name, data.game_type)
    local share_text = string.format("房间号ID: %d(%d局)\n%s\n%s\n", data.id, data.max_round, time, data.type_name)

    for _, v in pairs(result) do
        local text = string.format("姓名 %s 积分 【%d】\n", v.name, v.total_score)
        share_text = share_text .. text
    end

    Util.clipboardSetText(share_text)
    show_hint("当前战绩复制成功，您可以到支付宝/微信群内进行粘贴")
end

return function(result, parent, room_data, pos, type, tbl)
    result = result or ROOM_DATA_SHARE.total_result
    room_data = room_data or ROOM_DATA_SHARE
    
    if not parent then
        copy_result(result, room_data)
        return
    end

    local transform = UI.InitPrefab("over_buttons", parent)

    UI.OnClick(transform, "return", function()
        Destroy(parent.gameObject)
    end)

    tbl = tbl or {}
    table.insert(tbl, transform)
    UI.ShareScreen(transform, "share", type, tbl, true)
    
    local continue_btn = transform:Find("continue")
    if UI.Active(continue_btn, UI.room_continue) then
        UI.OnClick(continue_btn, nil, function()
            UI.room_continue()
            UI.room_continue = nil
        end)
    end
    
    require "feedback"(transform:Find("feedback"), room_data)

    if pos then
        transform.position = pos.position
    end
end
