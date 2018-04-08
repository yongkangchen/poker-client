using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Experimental_Director_AnimationMixerPlayable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.AnimationMixerPlayable o;
			o=new UnityEngine.Experimental.Director.AnimationMixerPlayable();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Experimental.Director.AnimationMixerPlayable");
		createTypeMetatable(l,constructor, typeof(UnityEngine.Experimental.Director.AnimationMixerPlayable),typeof(UnityEngine.Experimental.Director.AnimationPlayable));
	}
}
