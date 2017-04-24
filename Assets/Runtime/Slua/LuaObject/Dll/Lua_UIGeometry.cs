using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIGeometry : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UIGeometry o;
			o=new UIGeometry();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ApplyTransform(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.ApplyTransform(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteToBuffers(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			BetterList<UnityEngine.Vector3> a1;
			checkType(l,2,out a1);
			BetterList<UnityEngine.Vector2> a2;
			checkType(l,3,out a2);
			BetterList<UnityEngine.Color> a3;
			checkType(l,4,out a3);
			BetterList<UnityEngine.Vector3> a4;
			checkType(l,5,out a4);
			BetterList<UnityEngine.Vector4> a5;
			checkType(l,6,out a5);
			self.WriteToBuffers(a1,a2,a3,a4,a5);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verts(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verts(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			BetterList<UnityEngine.Vector3> v;
			checkType(l,2,out v);
			self.verts=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uvs(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uvs);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_uvs(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			BetterList<UnityEngine.Vector2> v;
			checkType(l,2,out v);
			self.uvs=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cols(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cols);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cols(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			BetterList<UnityEngine.Color> v;
			checkType(l,2,out v);
			self.cols=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hasVertices(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasVertices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hasTransformed(IntPtr l) {
		try {
			UIGeometry self=(UIGeometry)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasTransformed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIGeometry");
		addMember(l,Clear);
		addMember(l,ApplyTransform);
		addMember(l,WriteToBuffers);
		addMember(l,"verts",get_verts,set_verts,true);
		addMember(l,"uvs",get_uvs,set_uvs,true);
		addMember(l,"cols",get_cols,set_cols,true);
		addMember(l,"hasVertices",get_hasVertices,null,true);
		addMember(l,"hasTransformed",get_hasTransformed,null,true);
		createTypeMetatable(l,constructor, typeof(UIGeometry));
	}
}
