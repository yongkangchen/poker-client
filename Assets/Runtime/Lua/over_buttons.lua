local show_hint = require "hint"
local upgrade = require "app_upgrade"

local Destroy = UnityEngine.Object.Destroy

local function copy_result(result, data)
    if BDLocationUtil == nil then
        upgrade("app需要更新才能复制战绩")
        return
    end
    
    local share_text = ""
    
    time = os.date("%Y-%m-%d %H:%M", data.time)
    share_text = string.format("房间号ID: %d(%d局)\n%s\n%s\n", data.id, data.max_round, time, data.type_name)

    for _, v in pairs(result) do
        local text = string.format("姓名 %s 积分 【%d】\n", v.name, v.total_score)
        share_text = share_text .. text
    end
    
    Util.clipboardSetText(share_text)
    show_hint("当前战绩复制成功，您可以到支付宝/微信群内进行粘贴")
end

return function(result, parent, room_data, pos, type, tbl)    
    if not parent then
        copy_result(result, room_data)
        return
    end
    
    room_data = room_data or {
        time = os.time(),
        id  = ROOM_DATA_ID,
        max_round = ROOM_DATA_ROUND,
        type_name = ROOM_DATA_TYPE,
    }

    local transform = UI.InitPrefab("over_buttons", parent)
    
    UI.OnClick(transform, "return", function()
        Destroy(parent.gameObject)
    end)
    
    tbl = tbl or {}
    table.insert(tbl, transform)
    UI.ShareScreen(transform, "share", type, tbl)
    
    UI.OnClick(transform, "copy", function()
        copy_result(result, room_data)
    end)
    
    if pos then
        transform.position = pos.position
    end
end
