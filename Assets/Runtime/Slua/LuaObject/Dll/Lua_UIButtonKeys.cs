using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIButtonKeys : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UIButtonKeys o;
			o=new UIButtonKeys();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Upgrade(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			self.Upgrade();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectOnClick(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectOnClick);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectOnClick(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			UIButtonKeys v;
			checkType(l,2,out v);
			self.selectOnClick=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectOnUp(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectOnUp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectOnUp(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			UIButtonKeys v;
			checkType(l,2,out v);
			self.selectOnUp=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectOnDown(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectOnDown);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectOnDown(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			UIButtonKeys v;
			checkType(l,2,out v);
			self.selectOnDown=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectOnLeft(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectOnLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectOnLeft(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			UIButtonKeys v;
			checkType(l,2,out v);
			self.selectOnLeft=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectOnRight(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectOnRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectOnRight(IntPtr l) {
		try {
			UIButtonKeys self=(UIButtonKeys)checkSelf(l);
			UIButtonKeys v;
			checkType(l,2,out v);
			self.selectOnRight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIButtonKeys");
		addMember(l,Upgrade);
		addMember(l,"selectOnClick",get_selectOnClick,set_selectOnClick,true);
		addMember(l,"selectOnUp",get_selectOnUp,set_selectOnUp,true);
		addMember(l,"selectOnDown",get_selectOnDown,set_selectOnDown,true);
		addMember(l,"selectOnLeft",get_selectOnLeft,set_selectOnLeft,true);
		addMember(l,"selectOnRight",get_selectOnRight,set_selectOnRight,true);
		createTypeMetatable(l,constructor, typeof(UIButtonKeys),typeof(UIKeyNavigation));
	}
}
