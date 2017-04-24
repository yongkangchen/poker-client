using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_EventDelegate_Parameter : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			EventDelegate.Parameter o;
			if(argc==1){
				o=new EventDelegate.Parameter();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Object a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				o=new EventDelegate.Parameter(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				System.Object a1;
				checkType(l,2,out a1);
				o=new EventDelegate.Parameter(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_obj(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.obj);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_obj(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			UnityEngine.Object v;
			checkType(l,2,out v);
			self.obj=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_field(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.field);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_field(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.field=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_expectedType(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.expectedType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_expectedType(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.Type v;
			checkType(l,2,out v);
			self.expectedType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cached(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cached);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cached(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cached=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_propInfo(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.propInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_propInfo(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.Reflection.PropertyInfo v;
			checkType(l,2,out v);
			self.propInfo=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fieldInfo(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fieldInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fieldInfo(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.Reflection.FieldInfo v;
			checkType(l,2,out v);
			self.fieldInfo=v;
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
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
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
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			System.Object v;
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
	static public int get_type(IntPtr l) {
		try {
			EventDelegate.Parameter self=(EventDelegate.Parameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"EventDelegate.Parameter");
		addMember(l,"obj",get_obj,set_obj,true);
		addMember(l,"field",get_field,set_field,true);
		addMember(l,"expectedType",get_expectedType,set_expectedType,true);
		addMember(l,"cached",get_cached,set_cached,true);
		addMember(l,"propInfo",get_propInfo,set_propInfo,true);
		addMember(l,"fieldInfo",get_fieldInfo,set_fieldInfo,true);
		addMember(l,"value",get_value,set_value,true);
		addMember(l,"type",get_type,null,true);
		createTypeMetatable(l,constructor, typeof(EventDelegate.Parameter));
	}
}
