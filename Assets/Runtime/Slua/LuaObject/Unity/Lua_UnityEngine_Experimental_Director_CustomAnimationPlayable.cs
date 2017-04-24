using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Experimental_Director_CustomAnimationPlayable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable o;
			o=new UnityEngine.Experimental.Director.CustomAnimationPlayable();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Destroy(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			self.Destroy();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrepareFrame(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			UnityEngine.Experimental.Director.FrameData a1;
			checkValueType(l,2,out a1);
			self.PrepareFrame(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSetTime(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.OnSetTime(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSetPlayState(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			UnityEngine.Experimental.Director.PlayState a1;
			checkEnum(l,2,out a1);
			self.OnSetPlayState(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetInput(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetInput(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetOutput(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetOutput(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetInputWeight(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetInputWeight(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetInputWeight(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetInputWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddInput(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			UnityEngine.Experimental.Director.Playable a1;
			checkValueType(l,2,out a1);
			var ret=self.AddInput(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetInput(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			UnityEngine.Experimental.Director.Playable a1;
			checkValueType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.SetInput(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetInputs(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Collections.Generic.IEnumerable<UnityEngine.Experimental.Director.Playable> a1;
			checkType(l,2,out a1);
			var ret=self.SetInputs(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveInput(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.RemoveInput(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveAllInputs(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			var ret=self.RemoveAllInputs();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inputCount(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.inputCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_outputCount(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.outputCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_state(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.state);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_state(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			UnityEngine.Experimental.Director.PlayState v;
			checkEnum(l,2,out v);
			self.state=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			double v;
			checkType(l,2,out v);
			self.time=v;
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
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
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
			UnityEngine.Experimental.Director.CustomAnimationPlayable self=(UnityEngine.Experimental.Director.CustomAnimationPlayable)checkSelf(l);
			double v;
			checkType(l,2,out v);
			self.duration=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Experimental.Director.CustomAnimationPlayable");
		addMember(l,Destroy);
		addMember(l,PrepareFrame);
		addMember(l,OnSetTime);
		addMember(l,OnSetPlayState);
		addMember(l,GetInput);
		addMember(l,GetOutput);
		addMember(l,GetInputWeight);
		addMember(l,SetInputWeight);
		addMember(l,AddInput);
		addMember(l,SetInput);
		addMember(l,SetInputs);
		addMember(l,RemoveInput);
		addMember(l,RemoveAllInputs);
		addMember(l,"inputCount",get_inputCount,null,true);
		addMember(l,"outputCount",get_outputCount,null,true);
		addMember(l,"state",get_state,set_state,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"duration",get_duration,set_duration,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Experimental.Director.CustomAnimationPlayable),typeof(UnityEngine.Experimental.Director.ScriptPlayable));
	}
}
