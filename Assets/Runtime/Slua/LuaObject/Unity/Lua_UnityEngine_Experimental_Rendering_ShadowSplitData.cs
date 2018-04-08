using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Experimental_Rendering_ShadowSplitData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData o;
			o=new UnityEngine.Experimental.Rendering.ShadowSplitData();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCullingPlane(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetCullingPlane(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCullingPlane(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Plane a2;
			checkValueType(l,3,out a2);
			self.SetCullingPlane(a1,a2);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingPlaneCount(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cullingPlaneCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingPlaneCount(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.cullingPlaneCount=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingSphere(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cullingSphere);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingSphere(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.ShadowSplitData self;
			checkValueType(l,1,out self);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.cullingSphere=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Experimental.Rendering.ShadowSplitData");
		addMember(l,GetCullingPlane);
		addMember(l,SetCullingPlane);
		addMember(l,"cullingPlaneCount",get_cullingPlaneCount,set_cullingPlaneCount,true);
		addMember(l,"cullingSphere",get_cullingSphere,set_cullingSphere,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Experimental.Rendering.ShadowSplitData),typeof(System.ValueType));
	}
}
