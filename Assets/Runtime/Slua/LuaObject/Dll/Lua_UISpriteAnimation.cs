using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UISpriteAnimation : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RebuildSpriteList(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			self.RebuildSpriteList();
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
	static public int get_frames(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.frames);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_framesPerSecond(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_namePrefix(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.namePrefix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_namePrefix(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.namePrefix=v;
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
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
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			bool v;
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
	static public int get_isPlaying(IntPtr l) {
		try {
			UISpriteAnimation self=(UISpriteAnimation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isPlaying);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UISpriteAnimation");
		addMember(l,RebuildSpriteList);
		addMember(l,Play);
		addMember(l,Pause);
		addMember(l,ResetToBeginning);
		addMember(l,"frameIndex",get_frameIndex,set_frameIndex,true);
		addMember(l,"frames",get_frames,null,true);
		addMember(l,"framesPerSecond",get_framesPerSecond,set_framesPerSecond,true);
		addMember(l,"namePrefix",get_namePrefix,set_namePrefix,true);
		addMember(l,"loop",get_loop,set_loop,true);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		createTypeMetatable(l,null, typeof(UISpriteAnimation),typeof(UnityEngine.MonoBehaviour));
	}
}
