using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIDragCamera : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_draggableCamera(IntPtr l) {
		try {
			UIDragCamera self=(UIDragCamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.draggableCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_draggableCamera(IntPtr l) {
		try {
			UIDragCamera self=(UIDragCamera)checkSelf(l);
			UIDraggableCamera v;
			checkType(l,2,out v);
			self.draggableCamera=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIDragCamera");
		addMember(l,"draggableCamera",get_draggableCamera,set_draggableCamera,true);
		createTypeMetatable(l,null, typeof(UIDragCamera),typeof(UnityEngine.MonoBehaviour));
	}
}
