using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIPlaySound : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			self.Play();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_audioClip(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.audioClip);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_audioClip(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			UnityEngine.AudioClip v;
			checkType(l,2,out v);
			self.audioClip=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trigger(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.trigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_trigger(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			UIPlaySound.Trigger v;
			checkEnum(l,2,out v);
			self.trigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_volume(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.volume);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_volume(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.volume=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pitch(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pitch);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pitch(IntPtr l) {
		try {
			UIPlaySound self=(UIPlaySound)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.pitch=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIPlaySound");
		addMember(l,Play);
		addMember(l,"audioClip",get_audioClip,set_audioClip,true);
		addMember(l,"trigger",get_trigger,set_trigger,true);
		addMember(l,"volume",get_volume,set_volume,true);
		addMember(l,"pitch",get_pitch,set_pitch,true);
		createTypeMetatable(l,null, typeof(UIPlaySound),typeof(UnityEngine.MonoBehaviour));
	}
}
