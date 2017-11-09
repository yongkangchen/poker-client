
local Destroy = UnityEngine.Object.Destroy
local game = require "game"

return function (transform, close)
    local xf_transform = UI.InitPrefab("xufang", transform)
    UI.OnClick(xf_transform, "ensure", function()
        Destroy(transform.gameObject)
        close()
        game.create()
    end)
end
