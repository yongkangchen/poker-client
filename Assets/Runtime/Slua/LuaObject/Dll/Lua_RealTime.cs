using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_RealTime : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_time(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,RealTime.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deltaTime(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,RealTime.deltaTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"RealTime");
		addMember(l,"time",get_time,null,false);
		addMember(l,"deltaTime",get_deltaTime,null,false);
		createTypeMetatable(l,null, typeof(RealTime),typeof(UnityEngine.MonoBehaviour));
	}
}
