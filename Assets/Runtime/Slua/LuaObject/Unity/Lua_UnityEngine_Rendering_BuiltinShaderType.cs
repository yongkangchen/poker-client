using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Rendering_BuiltinShaderType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Rendering.BuiltinShaderType");
		addMember(l,0,"DeferredShading");
		addMember(l,1,"DeferredReflections");
		addMember(l,2,"LegacyDeferredLighting");
		addMember(l,3,"ScreenSpaceShadows");
		addMember(l,4,"DepthNormals");
		addMember(l,5,"LightHalo");
		addMember(l,6,"LensFlare");
		addMember(l,7,"Sprite");
		addMember(l,8,"MotionVectors");
		LuaDLL.lua_pop(l, 1);
	}
}
