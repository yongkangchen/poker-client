using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UICamera_ProcessEventsIn : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UICamera.ProcessEventsIn");
		addMember(l,0,"Update");
		addMember(l,1,"LateUpdate");
		LuaDLL.lua_pop(l, 1);
	}
}
