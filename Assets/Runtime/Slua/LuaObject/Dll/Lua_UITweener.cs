using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UITweener : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetOnFinished(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(EventDelegate))){
				UITweener self=(UITweener)checkSelf(l);
				EventDelegate a1;
				checkType(l,2,out a1);
				self.SetOnFinished(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(EventDelegate.Callback))){
				UITweener self=(UITweener)checkSelf(l);
				EventDelegate.Callback a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				self.SetOnFinished(a1);
				pushValue(l,true);
				return 1;
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
	static public int AddOnFinished(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(EventDelegate))){
				UITweener self=(UITweener)checkSelf(l);
				EventDelegate a1;
				checkType(l,2,out a1);
				self.AddOnFinished(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(EventDelegate.Callback))){
				UITweener self=(UITweener)checkSelf(l);
				EventDelegate.Callback a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				self.AddOnFinished(a1);
				pushValue(l,true);
				return 1;
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
	static public int RemoveOnFinished(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			EventDelegate a1;
			checkType(l,2,out a1);
			self.RemoveOnFinished(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Sample(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.Sample(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayForward(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.PlayForward();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayReverse(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.PlayReverse();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.Play(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetToBeginning(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.ResetToBeginning();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Toggle(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.Toggle();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetStartToCurrentValue(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.SetStartToCurrentValue();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetEndToCurrentValue(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			self.SetEndToCurrentValue();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UITweener.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			UITweener v;
			checkType(l,2,out v);
			UITweener.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_method(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.method);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_method(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			UITweener.Method v;
			checkEnum(l,2,out v);
			self.method=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_style(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.style);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_style(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			UITweener.Style v;
			checkEnum(l,2,out v);
			self.style=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_animationCurve(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.animationCurve);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_animationCurve(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.animationCurve=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreTimeScale(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreTimeScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreTimeScale(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.ignoreTimeScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_delay(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.delay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_delay(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.delay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_duration(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.duration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_duration(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.duration=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_steeperCurves(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.steeperCurves);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_steeperCurves(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.steeperCurves=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tweenGroup(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tweenGroup);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tweenGroup(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.tweenGroup=v;
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
			UITweener self=(UITweener)checkSelf(l);
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
			UITweener self=(UITweener)checkSelf(l);
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
			UITweener self=(UITweener)checkSelf(l);
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
			UITweener self=(UITweener)checkSelf(l);
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
			UITweener self=(UITweener)checkSelf(l);
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
			UITweener self=(UITweener)checkSelf(l);
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
	static public int get_amountPerDelta(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.amountPerDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tweenFactor(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tweenFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tweenFactor(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.tweenFactor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_direction(IntPtr l) {
		try {
			UITweener self=(UITweener)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.direction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UITweener");
		addMember(l,SetOnFinished);
		addMember(l,AddOnFinished);
		addMember(l,RemoveOnFinished);
		addMember(l,Sample);
		addMember(l,PlayForward);
		addMember(l,PlayReverse);
		addMember(l,Play);
		addMember(l,ResetToBeginning);
		addMember(l,Toggle);
		addMember(l,SetStartToCurrentValue);
		addMember(l,SetEndToCurrentValue);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"method",get_method,set_method,true);
		addMember(l,"style",get_style,set_style,true);
		addMember(l,"animationCurve",get_animationCurve,set_animationCurve,true);
		addMember(l,"ignoreTimeScale",get_ignoreTimeScale,set_ignoreTimeScale,true);
		addMember(l,"delay",get_delay,set_delay,true);
		addMember(l,"duration",get_duration,set_duration,true);
		addMember(l,"steeperCurves",get_steeperCurves,set_steeperCurves,true);
		addMember(l,"tweenGroup",get_tweenGroup,set_tweenGroup,true);
		addMember(l,"onFinished",get_onFinished,set_onFinished,true);
		addMember(l,"eventReceiver",get_eventReceiver,set_eventReceiver,true);
		addMember(l,"callWhenFinished",get_callWhenFinished,set_callWhenFinished,true);
		addMember(l,"amountPerDelta",get_amountPerDelta,null,true);
		addMember(l,"tweenFactor",get_tweenFactor,set_tweenFactor,true);
		addMember(l,"direction",get_direction,null,true);
		createTypeMetatable(l,null, typeof(UITweener),typeof(UnityEngine.MonoBehaviour));
	}
}
