using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIKeyNavigation : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLeft(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			var ret=self.GetLeft();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetRight(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			var ret=self.GetRight();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetUp(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			var ret=self.GetUp();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDown(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			var ret=self.GetDown();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Get(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			var ret=self.Get(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnNavigate(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.KeyCode a1;
			checkEnum(l,2,out a1);
			self.OnNavigate(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnKey(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.KeyCode a1;
			checkEnum(l,2,out a1);
			self.OnKey(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_list(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIKeyNavigation.list);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_list(IntPtr l) {
		try {
			BetterList<UIKeyNavigation> v;
			checkType(l,2,out v);
			UIKeyNavigation.list=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_constraint(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.constraint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_constraint(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UIKeyNavigation.Constraint v;
			checkEnum(l,2,out v);
			self.constraint=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onUp(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onUp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onUp(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onUp=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onDown(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onDown);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDown(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onDown=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onLeft(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onLeft(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onLeft=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onRight(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onRight(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onRight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onClick(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onClick);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onClick(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onClick=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onTab(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onTab);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onTab(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.onTab=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startsSelected(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startsSelected);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startsSelected(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.startsSelected=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mLastFrame(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIKeyNavigation.mLastFrame);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mLastFrame(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			UIKeyNavigation.mLastFrame=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIKeyNavigation.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isColliderEnabled(IntPtr l) {
		try {
			UIKeyNavigation self=(UIKeyNavigation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isColliderEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIKeyNavigation");
		addMember(l,GetLeft);
		addMember(l,GetRight);
		addMember(l,GetUp);
		addMember(l,GetDown);
		addMember(l,Get);
		addMember(l,OnNavigate);
		addMember(l,OnKey);
		addMember(l,"list",get_list,set_list,false);
		addMember(l,"constraint",get_constraint,set_constraint,true);
		addMember(l,"onUp",get_onUp,set_onUp,true);
		addMember(l,"onDown",get_onDown,set_onDown,true);
		addMember(l,"onLeft",get_onLeft,set_onLeft,true);
		addMember(l,"onRight",get_onRight,set_onRight,true);
		addMember(l,"onClick",get_onClick,set_onClick,true);
		addMember(l,"onTab",get_onTab,set_onTab,true);
		addMember(l,"startsSelected",get_startsSelected,set_startsSelected,true);
		addMember(l,"mLastFrame",get_mLastFrame,set_mLastFrame,false);
		addMember(l,"current",get_current,null,false);
		addMember(l,"isColliderEnabled",get_isColliderEnabled,null,true);
		createTypeMetatable(l,null, typeof(UIKeyNavigation),typeof(UnityEngine.MonoBehaviour));
	}
}
