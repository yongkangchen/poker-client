using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIScrollBar : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UIScrollBar o;
			o=new UIScrollBar();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceUpdate(IntPtr l) {
		try {
			UIScrollBar self=(UIScrollBar)checkSelf(l);
			self.ForceUpdate();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_barSize(IntPtr l) {
		try {
			UIScrollBar self=(UIScrollBar)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.barSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_barSize(IntPtr l) {
		try {
			UIScrollBar self=(UIScrollBar)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.barSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIScrollBar");
		addMember(l,ForceUpdate);
		addMember(l,"barSize",get_barSize,set_barSize,true);
		createTypeMetatable(l,constructor, typeof(UIScrollBar),typeof(UISlider));
	}
}
