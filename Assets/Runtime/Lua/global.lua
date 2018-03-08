--[[
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
--]]

WeChatUtil = WeChatUtil or {
    Reg = function() end,
    Login = function() end,
    Md5Sum = function() return tostring(os.clock()) end,
}

if not bit then
    bit = require "lib.numberlua".bit
end

require "lib.log"
require "lib.ext"
ThirdDLL = require "ThirdDLL"

local File = System.IO.File

sync = require "lib.sync"

local GameObject = UnityEngine.GameObject
local PlayerPrefs = UnityEngine.PlayerPrefs
local Instantiate = UnityEngine.Object.Instantiate

UI = {}

local click_audio
local function play_click_audio(is_close)
    local clip
    if is_close then
        clip = UI.LoadAudio("sound_win_close")
    else
        clip = UI.LoadAudio("sound_button_click")
    end
    
    if not click_audio then
        local click_obj = GameObject()
        click_obj.name = "click_obj"
        click_audio = click_obj:AddComponent(UnityEngine.AudioSource)
    end
    click_audio.clip = clip
    click_audio.volume = UI.GetVolume()
    click_audio:Play()
end

function UI.InitPrefab(path, parent)
    local prefab = ResourcesLoad("prefabs/" .. path)
    if not prefab then
        LERR("nil prefab: %s", path)
        return
    end
    
    local gameObject = Instantiate(prefab)
    local transform = gameObject.transform

    parent = parent or GameObject.Find("UI Root").transform
    transform:SetParent(parent, false)
    
    local toggles = gameObject:GetComponentsInChildren(UIToggle)
    LuaTimer.Add(1000, function()
        for i = 1, toggles.Length do
            EventDelegate.Add(toggles[i].onChange, function()
                play_click_audio()
            end)
        end
    end)
    
    return transform
end

function UI.InitWindow(path, parent)
    local transform = UI.InitPrefab(path, parent)
    -- assert(transform:GetComponent(UIPanel) ~= nil)
    if not transform:GetComponent(UIPanel) then 
        transform.gameObject:AddComponent(UIPanel).depth = 2
    end    
    --TODO: mask, depth = -100
    local mask = UI.InitPrefab("mask", transform)
    --TODO: 要设置mask的anchor使其全屏
    mask:GetComponent(UIWidget):SetAnchor(transform.gameObject, 0, 0, 0, 0)    
    mask:GetComponent(UI2DSprite).depth = -100
    
    return transform
end

UI.InitPrefabX = UI.InitPrefab
UI.InitWindowX = UI.InitWindow

function UI.Child(transform, path)
    if path == nil then
        return transform
    end

    local child = transform:Find(path)
    if child == nil then
        LERR("nil child: %s, %s", path, debug.traceback())
    end
    return child
end


function UI.OnClick(transform, path, func, scale)
    local obj = UI.Child(transform, path).gameObject
    if scale ~= false then
        obj:AddComponent(UIButtonScale).hover = UnityEngine.Vector3(1, 1, 1)
    end

    UIEventListener.Get(obj).onClick = function()
        local is_close = func()
        play_click_audio(is_close or obj.name == "close" or obj.name == "back")
    end
end


function UI.OnDoubleClick(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDoubleClick = func
end

function UI.OnPress(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onPress = func
end

function UI.OnHover(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onHover = func
end

function UI.OnDrag(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDrag = func
end

function UI.OnDragOver(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDragOver = func
end

function UI.OnDragOut(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDragOut = func
end

function UI.OnDragStart(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDragStart = func
end

function UI.OnDragEnd(transform, path, func)
    UIEventListener.Get(UI.Child(transform, path).gameObject).onDragEnd = func
end

function UI.Label(transform, path, value)
    UI.Child(transform, path):GetComponent(UILabel).text = value
end

function UI.GetComponent(transform, path, type)
    return UI.Child(transform, path):GetComponent(type)
end

function UI.Active(transform, v)
    transform.gameObject:SetActive(v ~= nil and v ~= false)
    return v
end

function UI.Children(transform)
    local tbl = {}
    for i = 0, transform.childCount - 1 do
        table.insert(tbl, transform:GetChild(i))
    end
    return tbl
end

local SpriteRenderer = UnityEngine.SpriteRenderer
function UI.LoadSprite(value, game_name)
    game_name = game_name and game_name .. "/" or ""
    local tbl = value:split("_")
    table.remove(tbl)

    local prefab_name = "altas/" .. game_name .. table.concat(tbl, "_")
    local prefab = ResourcesLoad(prefab_name)
    if not prefab then
        LERR("nil prefab: %s, %s", value, prefab_name)
    end
    
    local render = UI.GetComponent(prefab.transform, table.remove(value:split("/")), SpriteRenderer)
    -- print(render, value, prefab_name)
    return render.sprite
end

function UI.SpriteColorChange(transform, r, g, b, a)
    local color = transform:GetComponent(UIWidget).color
    color.r = r / 255.0
    color.g = g / 255.0
    color.b = b / 255.0
    color.a = a / 255.0
    transform:GetComponent(UIWidget).color = color
end

function UI.LabelColorChange(transform, path, r, g, b, a)
    local color = UI.Child(transform, path):GetComponent(UILabel).color
    color.r = r / 255.0
    color.g = g / 255.0
    color.b = b / 255.0
    color.a = a or 255 / 255.0
    UI.Child(transform, path):GetComponent(UILabel).color = color
end

function UI.Sprite(transform, path, value, game_name, perfect)
    if type(game_name) ~= "string" then
        perfect = game_name
        game_name = nil
    end
    
    local sprite = UI.GetComponent(transform, path, UI2DSprite)
    sprite.sprite2D = value and UI.LoadSprite(value, game_name) or nil
    if perfect then 
        sprite:MakePixelPerfect()
    end
end

function UI.LoadAudio(path)
    local audio = ResourcesLoad("sound/" .. path)
    if not audio then
        LERR("nil audio: %s", path)
    end
    return audio
end

function UI.LoadIcon(path)
    return ResourcesLoad(path)
end

local WWW = UnityEngine.WWW
local Yield = UnityEngine.Yield
local Texture2D = UnityEngine.Texture2D
local Object = UnityEngine.Object
function UI.RoleHead(transform, url, on_end)
    if not url then
        LERR("nil head url")
        local game_cfg = require "game_cfg"
        if not game_cfg.IS_VISITOR then
            return
        end
        
        if game_cfg.APPSTORE then
            return
        end
        
        url = url or "https://www.baidu.com/img/bd_logo1.png"
    end
    
    local texture = transform:GetComponent(UITexture)
    local name = WeChatUtil.Md5Sum(url):lower()
    local path = UnityEngine.Application.persistentDataPath .. "/"..name
    
    local new = Texture2D(2, 2)
    transform.gameObject:AddComponent(BehaviourEvent).onDestroy = function()
        Object.Destroy(new)
    end
    texture.mainTexture = new
    
    if File.Exists(path) then
        local data = File.ReadAllBytes(path)
        new:LoadImage(data)
        return
    end
    
    coroutine.wrap(function()    
        local www = WWW(url)
        Yield(www)
        if www.error then
            LERR("error download: %s, %s", url, www.text)
            return
        end
        
        if texture.mainTexture == new then
            www:LoadImageIntoTexture(new)
            File.WriteAllBytes(path, new:EncodeToPNG())
        end
        www:Dispose()
        if on_end then
            on_end()
        end
    end)()
end

local VOLUME_VOICE = "VOLUME_VOICE"
local volume
function UI.SetVolume(v)
    volume = v
    return PlayerPrefs.SetFloat(VOLUME_VOICE, v)
end

function UI.GetVolume()
    if not volume then
        volume = PlayerPrefs.GetFloat(VOLUME_VOICE, 1)
    end
    return volume
end

function UI.singleton_timer()
    local timer_id
    return function(sec, func)
        if timer_id then
            LuaTimer.Delete(timer_id)
        end
        
        if not sec then
            return
        end
        
        timer_id = LuaTimer.Add(sec, function()
            timer_id = nil
            func()
        end)
    end
end

function UI.Destroy(transform)
  GameObject.Destroy(transform.gameObject)
end

function UI.OnDestroy(transform, func)
    local be = transform.gameObject:AddComponent(BehaviourEvent)
    be.onApplicationQuit = function()
        be.onDestroy = nil
    end
    be.onDestroy = function()
        func()
    end
    return be
end

function UI.LimitName(name)
    if not name then
        return ""
    end

    local v = string.utf8sub(name, 1, 10)
    if v == name then
        return name
    end
    return string.utf8sub(name, 1, 8) .. ".."
end


function UI.TrimBlank(s)
    return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end

function UI.ShareScreen(transform, path, ...)
    if require "game_cfg".APPSTORE then
        UI.Active(transform:Find(path), false)
        return
    end

    local param = {...}

    UI.OnClick(transform, path, function()
        ShareScreenShot(unpack(param, 1, table.maxn(param)))
    end)
end
