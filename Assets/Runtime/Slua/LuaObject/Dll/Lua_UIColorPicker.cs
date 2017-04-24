using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIColorPicker : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Select(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Color))){
				UIColorPicker self=(UIColorPicker)checkSelf(l);
				UnityEngine.Color a1;
				checkType(l,2,out a1);
				var ret=self.Select(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2))){
				UIColorPicker self=(UIColorPicker)checkSelf(l);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				self.Select(a1);
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
	static public int Sample_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=UIColorPicker.Sample(a1,a2);
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
			pushValue(l,UIColorPicker.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			UIColorPicker v;
			checkType(l,2,out v);
			UIColorPicker.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_value(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_value(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.value=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectionWidget(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectionWidget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectionWidget(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			UIWidget v;
			checkType(l,2,out v);
			self.selectionWidget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onChange(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onChange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onChange(IntPtr l) {
		try {
			UIColorPicker self=(UIColorPicker)checkSelf(l);
			System.Collections.Generic.List<EventDelegate> v;
			checkType(l,2,out v);
			self.onChange=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIColorPicker");
		addMember(l,Select);
		addMember(l,Sample_s);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"value",get_value,set_value,true);
		addMember(l,"selectionWidget",get_selectionWidget,set_selectionWidget,true);
		addMember(l,"onChange",get_onChange,set_onChange,true);
		createTypeMetatable(l,null, typeof(UIColorPicker),typeof(UnityEngine.MonoBehaviour));
	}
}
