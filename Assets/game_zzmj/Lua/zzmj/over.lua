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

return function(result, player_data, on_close)
    local max_score = -1
    local max_pao = -1
    for _, data in ipairs(result) do
        local v = data.result.total_score
        if v > max_score then
            max_score = v
        end
        
        v = data.result.pao_count
        if v > max_pao then
            max_pao = v
        end
    end
    
    local transform = UI.InitWindow("zzmj/over")
    for i, trans in ipairs(UI.Children(transform:Find("player"))) do
        local data = result[i]
        if data then
            if data.is_host and player_data.id == data.id then
                require "xf.xufang"(transform, player_data.id_tbl,  player_data.create_params, player_data.up_room_id, on_close)
            end
            UI.Label(trans, "info/name", data.name)
            UI.Label(trans, "info/id", data.id)
            UI.RoleHead(trans:Find("info/head"), data.headimgurl)
            UI.Active(trans:Find("info/host"), data.is_host)
            UI.Active(trans:Find("bg/lightFrame"), data.is_self)
            local is_win = data.result.total_score == max_score and data.result.total_score > 0
            UI.Active(trans:Find("info/win"),  is_win)
            UI.Active(trans:Find("info/paoshou"), not is_win and (data.result.pao_count == max_pao and max_pao > 0))
            
            
            if data.result.total_score == 0 then
                UI.Label(trans:Find("split"), "total_score/score_win", 0)
                UI.Label(trans:Find("split"), "total_score/score_lose", "")
            elseif data.result.total_score > 0 then
                UI.Label(trans:Find("split"), "total_score/score_win", "+"..data.result.total_score)
                UI.Label(trans:Find("split"), "total_score/score_lose", "")
            elseif data.result.total_score < 0  then
                UI.Label(trans:Find("split"), "total_score/score_win", "")
                UI.Label(trans:Find("split"), "total_score/score_lose", data.result.total_score)
            end
            
            for _, label in ipairs(UI.Children(trans:Find("checknum"))) do
                --UI.Label(label, nil, data.result[label.name])
                --LLOG(data.result[label.name])
                UI.Label(label,"count",data.result[label.name])
            end
        else
            UI.Active(trans, false)
        end
    end
    
    UI.OnClick(transform, "buttons/share", function()
        ShareScreenShot()
    end)
    
    UI.OnClick(transform, "buttons/return", function()
        Destroy(transform.gameObject)
        on_close()
    end)
end
