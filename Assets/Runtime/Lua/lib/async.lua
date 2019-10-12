--[[
https://github.com/yongkangchen/lua-async
MIT License
Copyright (c) 2016 Yongkang Chen lx1988cyk#gmail.com
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
]]

local function parallel_task()
    local count = 0
    local co
    return {
        add = function(func)
            count = count + 1
            coroutine.wrap(function()
                func()
                count = count - 1
                if count == 0 and co then
                    coroutine.resume(co)
                    co = nil
                end
            end)()
        end,
        wait = function()
            if count ~= 0 then
                co = coroutine.running()
                coroutine.yield()
            end
        end
    }
end

return {
    parallel_task = parallel_task,
    parallel = function(task_tbl)
        local task = parallel_task()
        for _, v in ipairs(task_tbl) do
            task.add(v)
        end
        task.wait()
    end,
}
