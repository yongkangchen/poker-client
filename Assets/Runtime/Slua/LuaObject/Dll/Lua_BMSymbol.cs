using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_BMSymbol : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			BMSymbol o;
			o=new BMSymbol();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int MarkAsChanged(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			self.MarkAsChanged();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Validate(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			UIAtlas a1;
			checkType(l,2,out a1);
			var ret=self.Validate(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sequence(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sequence);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sequence(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.sequence=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spriteName(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
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
			BMSymbol self=(BMSymbol)checkSelf(l);
			System.String v;
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
	static public int get_length(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.length);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offsetX(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.offsetX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_offsetY(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.offsetY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_width(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.width);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_height(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.height);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_advance(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.advance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_uvRect(IntPtr l) {
		try {
			BMSymbol self=(BMSymbol)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uvRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"BMSymbol");
		addMember(l,MarkAsChanged);
		addMember(l,Validate);
		addMember(l,"sequence",get_sequence,set_sequence,true);
		addMember(l,"spriteName",get_spriteName,set_spriteName,true);
		addMember(l,"length",get_length,null,true);
		addMember(l,"offsetX",get_offsetX,null,true);
		addMember(l,"offsetY",get_offsetY,null,true);
		addMember(l,"width",get_width,null,true);
		addMember(l,"height",get_height,null,true);
		addMember(l,"advance",get_advance,null,true);
		addMember(l,"uvRect",get_uvRect,null,true);
		createTypeMetatable(l,constructor, typeof(BMSymbol));
	}
}
