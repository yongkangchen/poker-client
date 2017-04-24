using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UISavedOption : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SaveSelection(IntPtr l) {
		try {
			UISavedOption self=(UISavedOption)checkSelf(l);
			self.SaveSelection();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SaveState(IntPtr l) {
		try {
			UISavedOption self=(UISavedOption)checkSelf(l);
			self.SaveState();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SaveProgress(IntPtr l) {
		try {
			UISavedOption self=(UISavedOption)checkSelf(l);
			self.SaveProgress();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_keyName(IntPtr l) {
		try {
			UISavedOption self=(UISavedOption)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keyName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_keyName(IntPtr l) {
		try {
			UISavedOption self=(UISavedOption)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.keyName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UISavedOption");
		addMember(l,SaveSelection);
		addMember(l,SaveState);
		addMember(l,SaveProgress);
		addMember(l,"keyName",get_keyName,set_keyName,true);
		createTypeMetatable(l,null, typeof(UISavedOption),typeof(UnityEngine.MonoBehaviour));
	}
}
