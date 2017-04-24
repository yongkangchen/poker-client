using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIDragScrollView : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPan(IntPtr l) {
		try {
			UIDragScrollView self=(UIDragScrollView)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			self.OnPan(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrollView(IntPtr l) {
		try {
			UIDragScrollView self=(UIDragScrollView)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scrollView);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrollView(IntPtr l) {
		try {
			UIDragScrollView self=(UIDragScrollView)checkSelf(l);
			UIScrollView v;
			checkType(l,2,out v);
			self.scrollView=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIDragScrollView");
		addMember(l,OnPan);
		addMember(l,"scrollView",get_scrollView,set_scrollView,true);
		createTypeMetatable(l,null, typeof(UIDragScrollView),typeof(UnityEngine.MonoBehaviour));
	}
}
