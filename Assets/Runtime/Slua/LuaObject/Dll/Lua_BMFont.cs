using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_BMFont : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			BMFont o;
			o=new BMFont();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetGlyph(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				BMFont self=(BMFont)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetGlyph(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				BMFont self=(BMFont)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetGlyph(a1,a2);
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
	static public int Clear(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Trim(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			System.Int32 a4;
			checkType(l,5,out a4);
			self.Trim(a1,a2,a3,a4);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isValid(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_charSize(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.charSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_charSize(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.charSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_baseOffset(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.baseOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_baseOffset(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.baseOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_texWidth(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.texWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_texWidth(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.texWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_texHeight(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.texHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_texHeight(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.texHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_glyphCount(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.glyphCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spriteName(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spriteName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spriteName(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.spriteName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_glyphs(IntPtr l) {
		try {
			BMFont self=(BMFont)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.glyphs);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"BMFont");
		addMember(l,GetGlyph);
		addMember(l,Clear);
		addMember(l,Trim);
		addMember(l,"isValid",get_isValid,null,true);
		addMember(l,"charSize",get_charSize,set_charSize,true);
		addMember(l,"baseOffset",get_baseOffset,set_baseOffset,true);
		addMember(l,"texWidth",get_texWidth,set_texWidth,true);
		addMember(l,"texHeight",get_texHeight,set_texHeight,true);
		addMember(l,"glyphCount",get_glyphCount,null,true);
		addMember(l,"spriteName",get_spriteName,set_spriteName,true);
		addMember(l,"glyphs",get_glyphs,null,true);
		createTypeMetatable(l,constructor, typeof(BMFont));
	}
}
