using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Experimental_Rendering_CullingParameters : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters o;
			o=new UnityEngine.Experimental.Rendering.CullingParameters();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLayerCullDistance(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetLayerCullDistance(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLayerCullDistance(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetLayerCullDistance(a1,a2);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetCullingPlane(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
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
			UnityEngine.Experimental.Rendering.CullingParameters self;
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
	static public int get_isOrthographic(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isOrthographic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isOrthographic(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.isOrthographic=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lodParameters(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lodParameters);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lodParameters(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			UnityEngine.Experimental.Rendering.LODParameters v;
			checkValueType(l,2,out v);
			self.lodParameters=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingPlaneCount(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
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
			UnityEngine.Experimental.Rendering.CullingParameters self;
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
	static public int get_cullingMask(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cullingMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingMask(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.cullingMask=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullingMatrix(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cullingMatrix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullingMatrix(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			UnityEngine.Matrix4x4 v;
			checkValueType(l,2,out v);
			self.cullingMatrix=v;
			setBack(l,self);
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
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
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
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.position=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shadowDistance(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.shadowDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shadowDistance(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.shadowDistance=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_reflectionProbeSortOptions(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.reflectionProbeSortOptions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_reflectionProbeSortOptions(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.CullingParameters self;
			checkValueType(l,1,out self);
			UnityEngine.Experimental.Rendering.ReflectionProbeSortOptions v;
			checkEnum(l,2,out v);
			self.reflectionProbeSortOptions=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Experimental.Rendering.CullingParameters");
		addMember(l,GetLayerCullDistance);
		addMember(l,SetLayerCullDistance);
		addMember(l,GetCullingPlane);
		addMember(l,SetCullingPlane);
		addMember(l,"isOrthographic",get_isOrthographic,set_isOrthographic,true);
		addMember(l,"lodParameters",get_lodParameters,set_lodParameters,true);
		addMember(l,"cullingPlaneCount",get_cullingPlaneCount,set_cullingPlaneCount,true);
		addMember(l,"cullingMask",get_cullingMask,set_cullingMask,true);
		addMember(l,"cullingMatrix",get_cullingMatrix,set_cullingMatrix,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"shadowDistance",get_shadowDistance,set_shadowDistance,true);
		addMember(l,"reflectionProbeSortOptions",get_reflectionProbeSortOptions,set_reflectionProbeSortOptions,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Experimental.Rendering.CullingParameters),typeof(System.ValueType));
	}
}
