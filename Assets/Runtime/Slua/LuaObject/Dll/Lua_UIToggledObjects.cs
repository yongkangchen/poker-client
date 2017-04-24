using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIToggledObjects : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Toggle(IntPtr l) {
		try {
			UIToggledObjects self=(UIToggledObjects)checkSelf(l);
			self.Toggle();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activate(IntPtr l) {
		try {
			UIToggledObjects self=(UIToggledObjects)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_activate(IntPtr l) {
		try {
			UIToggledObjects self=(UIToggledObjects)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.GameObject> v;
			checkType(l,2,out v);
			self.activate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deactivate(IntPtr l) {
		try {
			UIToggledObjects self=(UIToggledObjects)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deactivate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_deactivate(IntPtr l) {
		try {
			UIToggledObjects self=(UIToggledObjects)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.GameObject> v;
			checkType(l,2,out v);
			self.deactivate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIToggledObjects");
		addMember(l,Toggle);
		addMember(l,"activate",get_activate,set_activate,true);
		addMember(l,"deactivate",get_deactivate,set_deactivate,true);
		createTypeMetatable(l,null, typeof(UIToggledObjects),typeof(UnityEngine.MonoBehaviour));
	}
}
