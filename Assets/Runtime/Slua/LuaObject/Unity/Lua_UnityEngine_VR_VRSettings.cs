using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_VR_VRSettings : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LoadDeviceByName_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(System.String[]))){
				System.String[] a1;
				checkArray(l,1,out a1);
				UnityEngine.XR.XRSettings.LoadDeviceByName(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.XR.XRSettings.LoadDeviceByName(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.XR.XRSettings.enabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showDeviceView(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.showDeviceView);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showDeviceView(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.XR.XRSettings.showDeviceView=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderScale(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.eyeTextureResolutionScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderScale(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.XR.XRSettings.eyeTextureResolutionScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eyeTextureWidth(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.eyeTextureWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eyeTextureHeight(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.eyeTextureHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderViewportScale(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.renderViewportScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderViewportScale(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.XR.XRSettings.renderViewportScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_loadedDeviceName(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.loadedDeviceName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_supportedDevices(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.XR.XRSettings.supportedDevices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.VR.VRSettings");
		addMember(l,LoadDeviceByName_s);
		addMember(l,"enabled",get_enabled,set_enabled,false);
		addMember(l,"showDeviceView",get_showDeviceView,set_showDeviceView,false);
		addMember(l,"renderScale",get_renderScale,set_renderScale,false);
		addMember(l,"eyeTextureWidth",get_eyeTextureWidth,null,false);
		addMember(l,"eyeTextureHeight",get_eyeTextureHeight,null,false);
		addMember(l,"renderViewportScale",get_renderViewportScale,set_renderViewportScale,false);
		addMember(l,"loadedDeviceName",get_loadedDeviceName,null,false);
		addMember(l,"supportedDevices",get_supportedDevices,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.XR.XRSettings));
	}
}
