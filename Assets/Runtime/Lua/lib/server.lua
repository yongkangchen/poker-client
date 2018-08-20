--[[
https://github.com/yongkangchen/lua-rpc

The MIT License (MIT)

Copyright (c) 2016 Yongkang Chen <lx1988cyk at gmail dot com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
--]]

local msg = require "data.msg"
local show_dialog = require "dialog"
local function msg_request( server, key )
	local v = msg[key:upper()]
	if not v then
		return
	end
	assert(type(v) == "number", key)
	return function(self, ... )
		if self == server then
			return server.send(true, v, ...)
		else
			return server.send(false, v, self, ...)
		end
	end
end

local resume = coroutine.resume

local server = {}
do
	setmetatable(server, {__index = msg_request})

	local buf = ""
	local wait_tbl = {}
	local halt
	local on_data
	local wait_data

	local listen_tbl = {}
	local msg_tbl = {}
	local function init_recv()
		buf = ""
		wait_data = true
		on_data = coroutine.wrap(function()
			while true do
				local start_pos, end_pos = buf:find("\r\n")
				if not start_pos then
					wait_data = true
					coroutine.yield()
					wait_data = false
				else
					local msg_data = buf:sub(1, start_pos - 1)
					buf = buf:sub(end_pos + 1)
					local result = server.unpack(msg_data)
					if result[1] < 0x0010 or not halt then
						server.dispatch(result)
					else
						table.insert(msg_tbl, result)
				end
			end
			end
		end)
	end

	server.dispatch = function(result)
		local len = table.maxn(result)
		local t = result[1]

		LLOG("on result: 0x%08x, len: %d, dump: %s, pack: %s", result[1], len, table.dump(result), table.dump({unpack(result, 2, len)}))

		local tbl = wait_tbl[t]
		local co
		if tbl then
			co = table.remove(tbl, 1)
			if #tbl == 0 then
				wait_tbl[t] = nil
			end
		end

		if co then
			resume(co, true, unpack(result, 2, len))
		else
			local func = listen_tbl[t]
			if func then
				local func_co = coroutine.create(func)
				coroutine.resume(func_co, unpack(result, 2, len))
			else
				LERR("t: %s", t or 0)
				LERR("unknow msg, code: 0x%08x", t or 0)
			end
		end
	end
	init_recv()
	SocketManager.onData = function(data)
		buf = buf .. Slua.ToString(data)
		if wait_data then
			on_data()
		end
	end

	SocketManager.onError = function( errno )
		LERR("errno: %s", errno)
		server.close()
		show_dialog("与服务器断开连接", function()
			UnityEngine.SceneManagement.SceneManager.LoadScene(0)
		end)
	end

	function server.sleep(sec)
		server.halt(true)
		LuaTimer.Add(sec, function()
			server.halt()
		end)
	end

	function server.halt(v)
		halt = v

		while not halt do
			local result = table.remove(msg_tbl, 1)
			if not result then
				break
			end
			server.dispatch(result)
		end
	end

	function server.close()
		init_recv()

		if table.is_empty(wait_tbl) then
			return
		end

		local tbl = wait_tbl
		wait_tbl = {}
		for _, co_tbl in pairs(tbl) do
			for _, co in pairs(co_tbl) do
				resume(co, false)
			end
		end
		LERR("网络异常，请求失败！")
	end

	local function check_result(ok, ...)
		if ok == false then
			error("disconncet")
		elseif ok == nil then
			error("killed")
		end
		return ...
	end

	local function do_wait(t)
		wait_tbl[t] = wait_tbl[t] or {}
		table.insert(wait_tbl[t], coroutine.running())
		return check_result(coroutine.yield())
	end

	function server.listen(t, func)
		listen_tbl[t] = func
	end

	function server.wait( t )
		t = msg[t:upper()]
		return do_wait(t)
	end

	server.pack = table.dump
	server.unpack = table.undump

	function server.send(wait, t, ... )
		local msg_data = server.pack({t, ...}) .. "\r\n"

		SocketManager.send(Slua.ToBytes(msg_data))

		LLOG("send: 0x%08x, %s", t, table.dump{...})

		if wait == false then
			return
		end

		return do_wait(t)
	end
end
return server
