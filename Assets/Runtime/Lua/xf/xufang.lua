
local Destroy = UnityEngine.Object.Destroy
local server = require "lib.server"
local msg = require "data.msg"
local game = require "game"

return function (transform, id_tbl, create_params, up_room_id, close)
    local xf_transform = UI.InitPrefab("xufang", transform)

    UI.OnClick(xf_transform, "ensure", function()
        Destroy(transform.gameObject)
        close()
        game.create(id_tbl, create_params, up_room_id)
    end)
end
