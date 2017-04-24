using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIDragDropContainer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_reparentTarget(IntPtr l) {
		try {
			UIDragDropContainer self=(UIDragDropContainer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reparentTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_reparentTarget(IntPtr l) {
		try {
			UIDragDropContainer self=(UIDragDropContainer)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.reparentTarget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIDragDropContainer");
		addMember(l,"reparentTarget",get_reparentTarget,set_reparentTarget,true);
		createTypeMetatable(l,null, typeof(UIDragDropContainer),typeof(UnityEngine.MonoBehaviour));
	}
}
