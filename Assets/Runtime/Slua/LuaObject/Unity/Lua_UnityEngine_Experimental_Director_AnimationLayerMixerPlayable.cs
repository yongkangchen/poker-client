using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Experimental_Director_AnimationLayerMixerPlayable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.AnimationLayerMixerPlayable o;
			o=new UnityEngine.Experimental.Director.AnimationLayerMixerPlayable();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Experimental.Director.AnimationLayerMixerPlayable");
		createTypeMetatable(l,constructor, typeof(UnityEngine.Experimental.Director.AnimationLayerMixerPlayable),typeof(UnityEngine.Experimental.Director.AnimationPlayable));
	}
}
