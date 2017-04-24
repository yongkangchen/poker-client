using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UITooltip : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Show_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UITooltip.Show(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Hide_s(IntPtr l) {
		try {
			UITooltip.Hide();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uiCamera(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
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
			UITooltip self=(UITooltip)checkSelf(l);
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
	static public int get_text(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.text);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_text(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			UILabel v;
			checkType(l,2,out v);
			self.text=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tooltipRoot(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tooltipRoot);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tooltipRoot(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.tooltipRoot=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_background(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.background);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_background(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			UISprite v;
			checkType(l,2,out v);
			self.background=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_appearSpeed(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.appearSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_appearSpeed(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.appearSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scalingTransitions(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scalingTransitions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scalingTransitions(IntPtr l) {
		try {
			UITooltip self=(UITooltip)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.scalingTransitions=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isVisible(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UITooltip.isVisible);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UITooltip");
		addMember(l,Show_s);
		addMember(l,Hide_s);
		addMember(l,"uiCamera",get_uiCamera,set_uiCamera,true);
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"tooltipRoot",get_tooltipRoot,set_tooltipRoot,true);
		addMember(l,"background",get_background,set_background,true);
		addMember(l,"appearSpeed",get_appearSpeed,set_appearSpeed,true);
		addMember(l,"scalingTransitions",get_scalingTransitions,set_scalingTransitions,true);
		addMember(l,"isVisible",get_isVisible,null,false);
		createTypeMetatable(l,null, typeof(UITooltip),typeof(UnityEngine.MonoBehaviour));
	}
}
