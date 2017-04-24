using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIStretch : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uiCamera(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uiCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uiCamera(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.uiCamera=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_container(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.container);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_container(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.container=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_style(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.style);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_style(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UIStretch.Style v;
			checkEnum(l,2,out v);
			self.style=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_runOnlyOnce(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.runOnlyOnce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_runOnlyOnce(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.runOnlyOnce=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_relativeSize(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.relativeSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_relativeSize(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.relativeSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_initialSize(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.initialSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_initialSize(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.initialSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_borderPadding(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.borderPadding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_borderPadding(IntPtr l) {
		try {
			UIStretch self=(UIStretch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.borderPadding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIStretch");
		addMember(l,"uiCamera",get_uiCamera,set_uiCamera,true);
		addMember(l,"container",get_container,set_container,true);
		addMember(l,"style",get_style,set_style,true);
		addMember(l,"runOnlyOnce",get_runOnlyOnce,set_runOnlyOnce,true);
		addMember(l,"relativeSize",get_relativeSize,set_relativeSize,true);
		addMember(l,"initialSize",get_initialSize,set_initialSize,true);
		addMember(l,"borderPadding",get_borderPadding,set_borderPadding,true);
		createTypeMetatable(l,null, typeof(UIStretch),typeof(UnityEngine.MonoBehaviour));
	}
}
