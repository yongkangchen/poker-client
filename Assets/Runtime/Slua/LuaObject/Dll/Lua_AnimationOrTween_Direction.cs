using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AnimationOrTween_Direction : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"AnimationOrTween.Direction");
		addMember(l,0,"Toggle");
		addMember(l,1,"Forward");
		addMember(l,-1,"Reverse");
		LuaDLL.lua_pop(l, 1);
	}
}
