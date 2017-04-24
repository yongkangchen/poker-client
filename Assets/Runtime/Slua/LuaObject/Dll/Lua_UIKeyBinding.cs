using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIKeyBinding : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsBound_s(IntPtr l) {
		try {
			UnityEngine.KeyCode a1;
			checkEnum(l,1,out a1);
			var ret=UIKeyBinding.IsBound(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetKeyCode_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.KeyCode a2;
			UIKeyBinding.Modifier a3;
			var ret=UIKeyBinding.GetKeyCode(a1,out a2,out a3);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			pushValue(l,a3);
			return 4;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_keyCode(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.keyCode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_keyCode(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.keyCode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_modifier(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.modifier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_modifier(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			UIKeyBinding.Modifier v;
			checkEnum(l,2,out v);
			self.modifier=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_action(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.action);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_action(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			UIKeyBinding.Action v;
			checkEnum(l,2,out v);
			self.action=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_captionText(IntPtr l) {
		try {
			UIKeyBinding self=(UIKeyBinding)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.captionText);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIKeyBinding");
		addMember(l,IsBound_s);
		addMember(l,GetKeyCode_s);
		addMember(l,"keyCode",get_keyCode,set_keyCode,true);
		addMember(l,"modifier",get_modifier,set_modifier,true);
		addMember(l,"action",get_action,set_action,true);
		addMember(l,"captionText",get_captionText,null,true);
		createTypeMetatable(l,null, typeof(UIKeyBinding),typeof(UnityEngine.MonoBehaviour));
	}
}
