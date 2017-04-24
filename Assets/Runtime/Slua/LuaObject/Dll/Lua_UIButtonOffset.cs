using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIButtonOffset : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tweenTarget(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tweenTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tweenTarget(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.tweenTarget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hover(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hover);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hover(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.hover=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pressed(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pressed(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.pressed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duration(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.duration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duration(IntPtr l) {
		try {
			UIButtonOffset self=(UIButtonOffset)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.duration=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIButtonOffset");
		addMember(l,"tweenTarget",get_tweenTarget,set_tweenTarget,true);
		addMember(l,"hover",get_hover,set_hover,true);
		addMember(l,"pressed",get_pressed,set_pressed,true);
		addMember(l,"duration",get_duration,set_duration,true);
		createTypeMetatable(l,null, typeof(UIButtonOffset),typeof(UnityEngine.MonoBehaviour));
	}
}
