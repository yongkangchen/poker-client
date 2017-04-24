using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIButtonActivate : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			UIButtonActivate self=(UIButtonActivate)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		try {
			UIButtonActivate self=(UIButtonActivate)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.target=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_state(IntPtr l) {
		try {
			UIButtonActivate self=(UIButtonActivate)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.state);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_state(IntPtr l) {
		try {
			UIButtonActivate self=(UIButtonActivate)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.state=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIButtonActivate");
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"state",get_state,set_state,true);
		createTypeMetatable(l,null, typeof(UIButtonActivate),typeof(UnityEngine.MonoBehaviour));
	}
}
