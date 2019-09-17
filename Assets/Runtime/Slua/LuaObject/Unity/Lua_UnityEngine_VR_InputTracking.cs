﻿using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_VR_InputTracking : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLocalPosition_s(IntPtr l) {
		try {
			UnityEngine.XR.XRNode a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.XR.InputTracking.GetLocalPosition(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLocalRotation_s(IntPtr l) {
		try {
			UnityEngine.XR.XRNode a1;
			checkEnum(l,1,out a1);
			var ret=UnityEngine.XR.InputTracking.GetLocalRotation(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Recenter_s(IntPtr l) {
		try {
			UnityEngine.XR.InputTracking.Recenter();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.VR.InputTracking");
		addMember(l,GetLocalPosition_s);
		addMember(l,GetLocalRotation_s);
		addMember(l,Recenter_s);
		createTypeMetatable(l,null, typeof(UnityEngine.XR.InputTracking));
	}
}
