using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Diagnostics_PlayerConnection : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_connected(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Diagnostics.PlayerConnection.connected);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Diagnostics.PlayerConnection");
		addMember(l,"connected",get_connected,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Diagnostics.PlayerConnection));
	}
}
