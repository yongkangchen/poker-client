using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIViewport : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sourceCamera(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sourceCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sourceCamera(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.sourceCamera=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_topLeft(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.topLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_topLeft(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.topLeft=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bottomRight(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bottomRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bottomRight(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.bottomRight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fullSize(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fullSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fullSize(IntPtr l) {
		try {
			UIViewport self=(UIViewport)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.fullSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIViewport");
		addMember(l,"sourceCamera",get_sourceCamera,set_sourceCamera,true);
		addMember(l,"topLeft",get_topLeft,set_topLeft,true);
		addMember(l,"bottomRight",get_bottomRight,set_bottomRight,true);
		addMember(l,"fullSize",get_fullSize,set_fullSize,true);
		createTypeMetatable(l,null, typeof(UIViewport),typeof(UnityEngine.MonoBehaviour));
	}
}
