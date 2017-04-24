using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AnimatedAlpha : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alpha(IntPtr l) {
		try {
			AnimatedAlpha self=(AnimatedAlpha)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alpha);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alpha(IntPtr l) {
		try {
			AnimatedAlpha self=(AnimatedAlpha)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.alpha=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AnimatedAlpha");
		addMember(l,"alpha",get_alpha,set_alpha,true);
		createTypeMetatable(l,null, typeof(AnimatedAlpha),typeof(UnityEngine.MonoBehaviour));
	}
}
