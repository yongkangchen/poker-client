using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Caching : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Caching o;
			o=new UnityEngine.Caching();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CleanCache_s(IntPtr l) {
		try {
			var ret=UnityEngine.Caching.ClearCache();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsVersionCached_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Hash128))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Hash128 a2;
				checkValueType(l,2,out a2);
				var ret=UnityEngine.Caching.IsVersionCached(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Caching.IsVersionCached(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
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
	static public int MarkAsUsed_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Hash128))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Hash128 a2;
				checkValueType(l,2,out a2);
				var ret=UnityEngine.Caching.MarkAsUsed(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Caching.MarkAsUsed(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
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
	static public int get_spaceFree(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.spaceFree);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maximumAvailableDiskSpace(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.maximumAvailableDiskSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maximumAvailableDiskSpace(IntPtr l) {
		try {
			System.Int64 v;
			checkType(l,2,out v);
			UnityEngine.Caching.maximumAvailableDiskSpace=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spaceOccupied(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.spaceOccupied);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_expirationDelay(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.expirationDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_expirationDelay(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Caching.expirationDelay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_compressionEnabled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.compressionEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_compressionEnabled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Caching.compressionEnabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ready(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Caching.ready);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Caching");
		addMember(l,CleanCache_s);
		addMember(l,IsVersionCached_s);
		addMember(l,MarkAsUsed_s);
		addMember(l,"spaceFree",get_spaceFree,null,false);
		addMember(l,"maximumAvailableDiskSpace",get_maximumAvailableDiskSpace,set_maximumAvailableDiskSpace,false);
		addMember(l,"spaceOccupied",get_spaceOccupied,null,false);
		addMember(l,"expirationDelay",get_expirationDelay,set_expirationDelay,false);
		addMember(l,"compressionEnabled",get_compressionEnabled,set_compressionEnabled,false);
		addMember(l,"ready",get_ready,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Caching));
	}
}
