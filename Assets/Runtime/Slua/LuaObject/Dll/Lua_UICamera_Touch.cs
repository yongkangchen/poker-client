using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UICamera_Touch : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UICamera.Touch o;
			o=new UICamera.Touch();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fingerId(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fingerId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fingerId(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.fingerId=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_phase(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.phase);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_phase(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			UnityEngine.TouchPhase v;
			checkEnum(l,2,out v);
			self.phase=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_position(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_position(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.position=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tapCount(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tapCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tapCount(IntPtr l) {
		try {
			UICamera.Touch self=(UICamera.Touch)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.tapCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UICamera.Touch");
		addMember(l,"fingerId",get_fingerId,set_fingerId,true);
		addMember(l,"phase",get_phase,set_phase,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"tapCount",get_tapCount,set_tapCount,true);
		createTypeMetatable(l,constructor, typeof(UICamera.Touch));
	}
}
