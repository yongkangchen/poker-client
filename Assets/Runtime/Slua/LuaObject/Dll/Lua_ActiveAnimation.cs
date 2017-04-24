using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_ActiveAnimation : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Finish(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			self.Finish();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			self.Reset();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animation a1;
				checkType(l,1,out a1);
				AnimationOrTween.Direction a2;
				checkEnum(l,2,out a2);
				var ret=ActiveAnimation.Play(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animation a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				AnimationOrTween.Direction a3;
				checkEnum(l,3,out a3);
				var ret=ActiveAnimation.Play(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Animator),typeof(string),typeof(AnimationOrTween.Direction),typeof(AnimationOrTween.EnableCondition),typeof(AnimationOrTween.DisableCondition))){
				UnityEngine.Animator a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				AnimationOrTween.Direction a3;
				checkEnum(l,3,out a3);
				AnimationOrTween.EnableCondition a4;
				checkEnum(l,4,out a4);
				AnimationOrTween.DisableCondition a5;
				checkEnum(l,5,out a5);
				var ret=ActiveAnimation.Play(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Animation),typeof(string),typeof(AnimationOrTween.Direction),typeof(AnimationOrTween.EnableCondition),typeof(AnimationOrTween.DisableCondition))){
				UnityEngine.Animation a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				AnimationOrTween.Direction a3;
				checkEnum(l,3,out a3);
				AnimationOrTween.EnableCondition a4;
				checkEnum(l,4,out a4);
				AnimationOrTween.DisableCondition a5;
				checkEnum(l,5,out a5);
				var ret=ActiveAnimation.Play(a1,a2,a3,a4,a5);
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
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,ActiveAnimation.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			ActiveAnimation v;
			checkType(l,2,out v);
			ActiveAnimation.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onFinished(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onFinished);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onFinished(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			System.Collections.Generic.List<EventDelegate> v;
			checkType(l,2,out v);
			self.onFinished=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventReceiver(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eventReceiver);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_eventReceiver(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.eventReceiver=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_callWhenFinished(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.callWhenFinished);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_callWhenFinished(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.callWhenFinished=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isPlaying(IntPtr l) {
		try {
			ActiveAnimation self=(ActiveAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isPlaying);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"ActiveAnimation");
		addMember(l,Finish);
		addMember(l,Reset);
		addMember(l,Play_s);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"onFinished",get_onFinished,set_onFinished,true);
		addMember(l,"eventReceiver",get_eventReceiver,set_eventReceiver,true);
		addMember(l,"callWhenFinished",get_callWhenFinished,set_callWhenFinished,true);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		createTypeMetatable(l,null, typeof(ActiveAnimation),typeof(UnityEngine.MonoBehaviour));
	}
}
