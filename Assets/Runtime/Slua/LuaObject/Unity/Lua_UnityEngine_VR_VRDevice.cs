using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_VR_VRDevice : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetNativePtr_s(IntPtr l) {
		try {
			var ret=UnityEngine.XR.XRDevice.GetNativePtr();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPresent(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRDevice.isPresent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_model(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRDevice.model);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_refreshRate(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRDevice.refreshRate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.VR.VRDevice");
		addMember(l,GetNativePtr_s);
		addMember(l,"isPresent",get_isPresent,null,false);
		addMember(l,"model",get_model,null,false);
		addMember(l,"refreshRate",get_refreshRate,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.XR.XRDevice));
	}
}
