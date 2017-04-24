using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIWrapContent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SortBasedOnScrollMovement(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			self.SortBasedOnScrollMovement();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SortAlphabetically(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			self.SortAlphabetically();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WrapContent(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			self.WrapContent();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemSize(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.itemSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemSize(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.itemSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cullContent(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cullContent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cullContent(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.cullContent=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minIndex(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_minIndex(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.minIndex=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxIndex(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxIndex(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.maxIndex=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hideInactive(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hideInactive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hideInactive(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.hideInactive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onInitializeItem(IntPtr l) {
		try {
			UIWrapContent self=(UIWrapContent)checkSelf(l);
			UIWrapContent.OnInitializeItem v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onInitializeItem=v;
			else if(op==1) self.onInitializeItem+=v;
			else if(op==2) self.onInitializeItem-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIWrapContent");
		addMember(l,SortBasedOnScrollMovement);
		addMember(l,SortAlphabetically);
		addMember(l,WrapContent);
		addMember(l,"itemSize",get_itemSize,set_itemSize,true);
		addMember(l,"cullContent",get_cullContent,set_cullContent,true);
		addMember(l,"minIndex",get_minIndex,set_minIndex,true);
		addMember(l,"maxIndex",get_maxIndex,set_maxIndex,true);
		addMember(l,"hideInactive",get_hideInactive,set_hideInactive,true);
		addMember(l,"onInitializeItem",null,set_onInitializeItem,true);
		createTypeMetatable(l,null, typeof(UIWrapContent),typeof(UnityEngine.MonoBehaviour));
	}
}
