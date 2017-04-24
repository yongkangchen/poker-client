using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIButtonMessage : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
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
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			UnityEngine.GameObject v;
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
	static public int get_functionName(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.functionName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_functionName(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.functionName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trigger(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.trigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_trigger(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			UIButtonMessage.Trigger v;
			checkEnum(l,2,out v);
			self.trigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_includeChildren(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.includeChildren);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_includeChildren(IntPtr l) {
		try {
			UIButtonMessage self=(UIButtonMessage)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.includeChildren=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIButtonMessage");
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"functionName",get_functionName,set_functionName,true);
		addMember(l,"trigger",get_trigger,set_trigger,true);
		addMember(l,"includeChildren",get_includeChildren,set_includeChildren,true);
		createTypeMetatable(l,null, typeof(UIButtonMessage),typeof(UnityEngine.MonoBehaviour));
	}
}
