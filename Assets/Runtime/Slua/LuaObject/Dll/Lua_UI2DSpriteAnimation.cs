using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UI2DSpriteAnimation : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			self.Play();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			self.Pause();
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
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			self.ResetToBeginning();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_frameIndex(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.frameIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_frameIndex(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.frameIndex=v;
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
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
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
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
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
	static public int get_loop(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.loop);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_loop(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.loop=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_frames(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.frames);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_frames(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			UnityEngine.Sprite[] v;
			checkArray(l,2,out v);
			self.frames=v;
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
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isPlaying);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_framesPerSecond(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.framesPerSecond);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_framesPerSecond(IntPtr l) {
		try {
			UI2DSpriteAnimation self=(UI2DSpriteAnimation)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.framesPerSecond=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UI2DSpriteAnimation");
		addMember(l,Play);
		addMember(l,Pause);
		addMember(l,ResetToBeginning);
		addMember(l,"frameIndex",get_frameIndex,set_frameIndex,true);
		addMember(l,"ignoreTimeScale",get_ignoreTimeScale,set_ignoreTimeScale,true);
		addMember(l,"loop",get_loop,set_loop,true);
		addMember(l,"frames",get_frames,set_frames,true);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		addMember(l,"framesPerSecond",get_framesPerSecond,set_framesPerSecond,true);
		createTypeMetatable(l,null, typeof(UI2DSpriteAnimation),typeof(UnityEngine.MonoBehaviour));
	}
}
