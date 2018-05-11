local sandbox = {}

local env = {}

([[
_VERSION assert error        ipairs     next pairs
pcall        select tonumber tostring type unpack xpcall
coroutine.create coroutine.resume coroutine.running coroutine.status
coroutine.wrap     coroutine.yield
math.abs     math.acos math.asin    math.atan math.atan2 math.ceil math.mod
math.cos     math.cosh math.deg     math.exp    math.fmod    math.floor
math.frexp math.huge math.ldexp math.log    math.log10 math.max
math.min     math.modf math.pi        math.pow    math.rad     math.random
math.sin     math.sinh math.sqrt    math.tan    math.tanh
os.clock os.difftime os.time os.date
string.byte string.char    string.find    string.format string.gmatch
string.gsub string.len     string.lower string.match    string.reverse
string.sub    string.upper string.gfind
table.insert table.maxn table.remove table.sort
table.foreach table.foreachi table.getn table.concat
bit print 
]]):gsub('%S+', function(id)
    local module, method = id:match('([^%.]+)%.([^%.]+)')
    if module then
        env[module] = env[module] or {}
        env[module][method] = _G[module][method]
    else
        env[id] = _G[id]
    end
end)

local function read_only(module_var, module_name)
    local tbl = {
        __newindex = function(_, attr_name, _)
            error('Can not modify ' .. module_name .. '.' .. attr_name .. '. Protected by the sandbox.', 2)
        end,
    }
    if type(module_var) == "function" then
        tbl["__call"] = function(_, ...)
            return module_var(...)
        end
    else
        tbl["__index"] = module_var
    end
    return setmetatable({}, tbl)
end

('coroutine math os string table bit'):gsub('%S+', function(module_name)
    env[module_name] = read_only(env[module_name], module_name)
end)

sandbox.read_only = read_only

function sandbox.set_env(k, v)
    rawset(env, k, v)
end

function sandbox.set_env_method(m, k, v)
    rawset(env[m], k, v)
end

env._G = env

local read_only_env = read_only(env, "_G")

function sandbox.protect(f)
    setfenv(f, read_only_env)
    return f
end

function sandbox.run(f, options, ...)
    return sandbox.protect(f, options)(...)
end

return sandbox
