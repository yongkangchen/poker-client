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
