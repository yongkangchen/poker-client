using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_NGUIDebug : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateInstance_s(IntPtr l) {
		try {
			NGUIDebug.CreateInstance();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Log_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				NGUIDebug.Log(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(object[]))){
				System.Object[] a1;
				checkParams(l,1,out a1);
				NGUIDebug.Log(a1);
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
	static public int Clear_s(IntPtr l) {
		try {
			NGUIDebug.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DrawBounds_s(IntPtr l) {
		try {
			UnityEngine.Bounds a1;
			checkValueType(l,1,out a1);
			NGUIDebug.DrawBounds(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_debugRaycast(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,NGUIDebug.debugRaycast);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_debugRaycast(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			NGUIDebug.debugRaycast=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"NGUIDebug");
		addMember(l,CreateInstance_s);
		addMember(l,Log_s);
		addMember(l,Clear_s);
		addMember(l,DrawBounds_s);
		addMember(l,"debugRaycast",get_debugRaycast,set_debugRaycast,false);
		createTypeMetatable(l,null, typeof(NGUIDebug),typeof(UnityEngine.MonoBehaviour));
	}
}
