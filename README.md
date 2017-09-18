# poker-client

It has been tested on Windows 7, Mac OS X with Unity3D 5.4.1f1

Please buy NGUI 3.10.0 and import NGUI3.10.0.unitypackage

http://linkcloud.github.io/

# Run
`Assets/Runtime/main.unity`

# Config
`Assets/game_zzmj/Lua/game_cfg.lua`

```lua
DEV_HOST = "127.0.0.1", --服务器地址
DEV_PORT = 9878, --服务器端口
```

# 商业版-安卓手机包测试

http://cdn.u3d.biucloud.com/com.biucloud.game.preview.apk

 ![image](https://github.com/yongkangchen/poker-client/blob/master/android.png?raw=true)

# 开发规范
1、下载客户端和服务器工程： 

https://github.com/yongkangchen/poker-client

https://github.com/yongkangchen/poker-server

2、PC打包 

勾选Development Build不会打包lua脚本，需要放到和Assets目录同级下运行，共享编辑器里的脚本 

不勾选会打包lua脚本，可以发给测试 


3、Unity里的main场景配置Main Folder 

4、放置路径：

脚本：Assets/game_${GAME_NAME}/Lua/${GAME_NAME} 

UI预设：Assets/game_${GAME_NAME}/Resources/prefabs/${GAME_NAME} 

声音：Assets/game_${GAME_NAME}/Resources/sound/${GAME_NAME} 

图集：Assets/game_${GAME_NAME}/Resources/altas/${GAME_NAME} 

5、第一次启动untiy工程：提示是否要生成slua，选择不生成 

6、不能写C#代码，因为不能热更新 

7、lua禁止写全局变量 

8、客户端的Assets/Runtime和Assets/Simple尽量不修改 

9、UILable不要使用Unity默认的字体，要用NGUI的字体，否则会导致打包失败

10、请确保`Assets/Runtime/Lua/data/msg.lua`和`Assets/game_zzmj/Lua/game_msg.lua`两个消息文件内的键值对不要重复，否则会报错：`!!! duplicate val in game_msg` 或者`!!! duplicate key in game_msg`

11、截屏微信分享函数：
```
ShareScreenShot(type, tbl)
type为nil或者0表示分享给好友，1表示分享到朋友圈

tbl是数组，每个元素是一个gameObject，会在截屏前将tbl里的所有gameObject隐藏掉，截屏后会将tbl所有的gameObject显示出来。
```

12、大厅内的授权开房功能配置：
`game_cfg.lua里添加：ACCREDIT = true, -- 授权开房`

13、分享app标题设置：`game_cfg.lua里添加：PRODUCT_NAME = "xx棋牌",` 
