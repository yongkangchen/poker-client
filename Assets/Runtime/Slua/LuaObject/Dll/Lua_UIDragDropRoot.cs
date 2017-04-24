using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIDragDropRoot : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_root(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIDragDropRoot.root);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_root(IntPtr l) {
		try {
			UnityEngine.Transform v;
			checkType(l,2,out v);
			UIDragDropRoot.root=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIDragDropRoot");
		addMember(l,"root",get_root,set_root,false);
		createTypeMetatable(l,null, typeof(UIDragDropRoot),typeof(UnityEngine.MonoBehaviour));
	}
}
