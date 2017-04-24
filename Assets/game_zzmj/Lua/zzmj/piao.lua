--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

local server = require "lib.server"
return function(parent)
    local transform = UI.InitPrefab("zzmj/piao", parent)
    for _, trans in ipairs(UI.Children(transform)) do
        UI.OnClick(trans, nil, function()
            server.piao(tonumber(trans.name))
            UI.Destroy(transform)
        end)
    end
end
