using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_BehaviourEvent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDestroy(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onDestroy=v;
			else if(op==1) self.onDestroy+=v;
			else if(op==2) self.onDestroy-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onEnable(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onEnable=v;
			else if(op==1) self.onEnable+=v;
			else if(op==2) self.onEnable-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDisable(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onDisable=v;
			else if(op==1) self.onDisable+=v;
			else if(op==2) self.onDisable-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onApplicationPause(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.BoolDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onApplicationPause=v;
			else if(op==1) self.onApplicationPause+=v;
			else if(op==2) self.onApplicationPause-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onApplicationQuit(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onApplicationQuit=v;
			else if(op==1) self.onApplicationQuit+=v;
			else if(op==2) self.onApplicationQuit-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onTriggerEnter2D(IntPtr l) {
		try {
			BehaviourEvent self=(BehaviourEvent)checkSelf(l);
			BehaviourEvent.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onTriggerEnter2D=v;
			else if(op==1) self.onTriggerEnter2D+=v;
			else if(op==2) self.onTriggerEnter2D-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"BehaviourEvent");
		addMember(l,"onDestroy",null,set_onDestroy,true);
		addMember(l,"onEnable",null,set_onEnable,true);
		addMember(l,"onDisable",null,set_onDisable,true);
		addMember(l,"onApplicationPause",null,set_onApplicationPause,true);
		addMember(l,"onApplicationQuit",null,set_onApplicationQuit,true);
		addMember(l,"onTriggerEnter2D",null,set_onTriggerEnter2D,true);
		createTypeMetatable(l,null, typeof(BehaviourEvent),typeof(UnityEngine.MonoBehaviour));
	}
}
