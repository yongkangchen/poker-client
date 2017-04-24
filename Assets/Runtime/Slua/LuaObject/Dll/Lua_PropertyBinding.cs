using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_PropertyBinding : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateTarget(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			self.UpdateTarget();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_source(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.source);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_source(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			PropertyReference v;
			checkType(l,2,out v);
			self.source=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			PropertyReference v;
			checkType(l,2,out v);
			self.target=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_direction(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.direction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_direction(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			PropertyBinding.Direction v;
			checkEnum(l,2,out v);
			self.direction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_update(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.update);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_update(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			PropertyBinding.UpdateCondition v;
			checkEnum(l,2,out v);
			self.update=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_editMode(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.editMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_editMode(IntPtr l) {
		try {
			PropertyBinding self=(PropertyBinding)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.editMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"PropertyBinding");
		addMember(l,UpdateTarget);
		addMember(l,"source",get_source,set_source,true);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"direction",get_direction,set_direction,true);
		addMember(l,"update",get_update,set_update,true);
		addMember(l,"editMode",get_editMode,set_editMode,true);
		createTypeMetatable(l,null, typeof(PropertyBinding),typeof(UnityEngine.MonoBehaviour));
	}
}
