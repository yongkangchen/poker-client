--[[
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

local function assert_ok(ok, err, ...)
    if not ok then
        error(err)
        return
    end
    return err, ...
end

local coroutine = coroutine
coroutine.wrap = function(f)
    local co = coroutine.create(f)
    return function(...)
        return assert_ok(coroutine.resume(co, ...))
    end
end

local table = table
function table.dump( object, cache )
    if type(object) == 'table' then
        cache = cache or {}
        if cache[object] then
            return ""
        end
        cache[object] = true
        local s = '{ '
        for k,v in pairs(object) do
            if type(k) ~= 'number' then k = '"'..k..'"' end
            s = s .. '['..k..'] = ' .. table.dump(v, cache) .. ','
        end
        return s .. '} '
    elseif type(object) == 'function' then
        return "@@@function"
    elseif type(object) == 'string' then
        return string.format("%q", object)
    else
        return tostring(object)
    end
end

function table.undump( str )
    if not str then
        return
    end

    local fun = loadstring( "return ".. str )
    if fun then
        return fun()
    end
end

function table.is_empty( tbl )
    return ( tbl == nil ) or ( _G.next( tbl ) == nil )
end

function table.copy( src )
    local dst = {}
    for k,v in pairs(src) do
        dst[k] = v
    end
    return dst
end

function table.index(tbl, obj)
    if tbl == nil or obj == nil then
        return nil
    end
    for i,v in pairs(tbl) do
        if v == obj then
            return i
        end
    end
    return nil
end

function table.length(tbl)
    local n = 0
    for _ in pairs(tbl) do
        n = n + 1
    end
    return n
end

function table.update(old, new)
    for k in pairs(old) do
        old[k] = nil
    end
    for k,v in pairs(new) do
        old[k] = v
    end
end


function table.remove_values(tbl, value, count)
    local n = 0
    count = count or 1
    for i = #tbl, 1, -1 do
        if tbl[i] == value then
            table.remove(tbl, i)
            n = n + 1
            count = count - 1
            if count == 0 then
                return n
            end
        end
    end
    return n
end

function table.merge(dst, src)
    for k, v in pairs(src) do
        dst[k] = v
    end
    return dst
end

function table.is_same_day( date_a, date_b )
    return date_a.yday == date_b.yday
        and date_a.year == date_b.year
end

local string = string
function string:split(_sep)
    local sep, fields = _sep or ":", {}
    local pattern = string.format("([^%s]+)", sep)
    self:gsub(pattern, function(c) fields[#fields+1] = c end)
    return fields
end

local function chsize(char)
    if char > 251 then
        return 6
    elseif char > 247 then
        return 5
    elseif char > 239 then
        return 4
    elseif char > 223 then
        return 3
    elseif char > 191 then
        return 2
    else
        return 1
    end
end

local function str_sub(str, startIndex, numChars)
    while numChars > 1 and startIndex <= #str do
        local char = string.byte(str, startIndex)	  
        startIndex = startIndex + chsize(char)	
        numChars = numChars - 1
    end
    return startIndex
end

function string.utf8sub(str, startChar, numChars)--NOTE 这里的char不是字节
    if not str then
        return
    end
    local startIndex = str_sub(str, 1, startChar)
    local currentIndex = str_sub(str, startIndex, numChars + 1)
    return str:sub(startIndex, currentIndex - 1)
end