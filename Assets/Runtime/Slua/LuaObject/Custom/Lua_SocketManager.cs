using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SocketManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			SocketManager o;
			o=new SocketManager();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int send_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkArray(l,1,out a1);
			SocketManager.send(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int dispose_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			SocketManager.dispose(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onError(IntPtr l) {
		try {
			System.Action<System.Int32> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) SocketManager.onError=v;
			else if(op==1) SocketManager.onError+=v;
			else if(op==2) SocketManager.onError-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onData(IntPtr l) {
		try {
			System.Action<System.Byte[]> v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) SocketManager.onData=v;
			else if(op==1) SocketManager.onData+=v;
			else if(op==2) SocketManager.onData-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_HOST(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,SocketManager.HOST);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_HOST(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			SocketManager.HOST=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_PORT(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,SocketManager.PORT);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_PORT(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			SocketManager.PORT=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SocketManager");
		addMember(l,send_s);
		addMember(l,dispose_s);
		addMember(l,"onError",null,set_onError,false);
		addMember(l,"onData",null,set_onData,false);
		addMember(l,"HOST",get_HOST,set_HOST,false);
		addMember(l,"PORT",get_PORT,set_PORT,false);
		createTypeMetatable(l,constructor, typeof(SocketManager));
	}
}
