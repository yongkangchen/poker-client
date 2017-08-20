do
    local msg = require "data.msg"
	local val_tbl = {}
    for k, v in pairs(require "game_msg") do
        if msg[k] == nil then
			if val_tbl[v] then
				LERR("!!! duplicate val in game_msg, k: %s => cur: %s, v: 0x%08x", k, val_tbl[v], v)
			end
            msg[k] = v
			val_tbl[v] = k
        else
            LERR("!!! duplicate key in game_msg, k: %s, v: 0x%08x => cur: 0x%08x", k, v, msg[k])
        end
    end
end