using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AnimatedColor : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_color(IntPtr l) {
		try {
			AnimatedColor self=(AnimatedColor)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_color(IntPtr l) {
		try {
			AnimatedColor self=(AnimatedColor)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AnimatedColor");
		addMember(l,"color",get_color,set_color,true);
		createTypeMetatable(l,null, typeof(AnimatedColor),typeof(UnityEngine.MonoBehaviour));
	}
}
