using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_VRTextureUsage : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.VRTextureUsage");
		addMember(l,0,"None");
		addMember(l,1,"OneEye");
		addMember(l,2,"TwoEyes");
		LuaDLL.lua_pop(l, 1);
	}
}
