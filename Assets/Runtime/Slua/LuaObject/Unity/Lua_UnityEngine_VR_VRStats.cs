using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_VR_VRStats : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_gpuTimeLastFrame(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.VR.VRStats.gpuTimeLastFrame);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.VR.VRStats");
		addMember(l,"gpuTimeLastFrame",get_gpuTimeLastFrame,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.VR.VRStats));
	}
}
