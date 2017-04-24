using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UILabel_Modifier : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UILabel.Modifier");
		addMember(l,0,"None");
		addMember(l,1,"ToUppercase");
		addMember(l,2,"ToLowercase");
		addMember(l,255,"Custom");
		LuaDLL.lua_pop(l, 1);
	}
}
