using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SpringPosition : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Begin_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=SpringPosition.Begin(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,SpringPosition.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			SpringPosition v;
			checkType(l,2,out v);
			SpringPosition.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
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
			SpringPosition self=(SpringPosition)checkSelf(l);
			UnityEngine.Vector3 v;
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
	static public int get_strength(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.strength);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_strength(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.strength=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_worldSpace(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_worldSpace(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.worldSpace=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreTimeScale(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreTimeScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreTimeScale(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ignoreTimeScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_updateScrollView(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updateScrollView);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_updateScrollView(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.updateScrollView=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onFinished(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			SpringPosition.OnFinished v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onFinished=v;
			else if(op==1) self.onFinished+=v;
			else if(op==2) self.onFinished-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_callWhenFinished(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.callWhenFinished);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_callWhenFinished(IntPtr l) {
		try {
			SpringPosition self=(SpringPosition)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.callWhenFinished=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SpringPosition");
		addMember(l,Begin_s);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"strength",get_strength,set_strength,true);
		addMember(l,"worldSpace",get_worldSpace,set_worldSpace,true);
		addMember(l,"ignoreTimeScale",get_ignoreTimeScale,set_ignoreTimeScale,true);
		addMember(l,"updateScrollView",get_updateScrollView,set_updateScrollView,true);
		addMember(l,"onFinished",null,set_onFinished,true);
		addMember(l,"callWhenFinished",get_callWhenFinished,set_callWhenFinished,true);
		createTypeMetatable(l,null, typeof(SpringPosition),typeof(UnityEngine.MonoBehaviour));
	}
}
