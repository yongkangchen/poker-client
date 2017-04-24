using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIRoot : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPixelSizeAdjustment(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPixelSizeAdjustment(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UpdateScale(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.UpdateScale(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetPixelSizeAdjustment_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UIRoot.GetPixelSizeAdjustment(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Broadcast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				UIRoot.Broadcast(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Object a2;
				checkType(l,2,out a2);
				UIRoot.Broadcast(a1,a2);
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
	static public int get_list(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIRoot.list);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_list(IntPtr l) {
		try {
			System.Collections.Generic.List<UIRoot> v;
			checkType(l,2,out v);
			UIRoot.list=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scalingStyle(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.scalingStyle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scalingStyle(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			UIRoot.Scaling v;
			checkEnum(l,2,out v);
			self.scalingStyle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_manualWidth(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.manualWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_manualWidth(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.manualWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_manualHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.manualHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_manualHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.manualHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_minimumHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minimumHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_minimumHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.minimumHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maximumHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maximumHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maximumHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.maximumHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fitWidth(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fitWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fitWidth(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.fitWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fitHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fitHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fitHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.fitHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_adjustByDPI(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.adjustByDPI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_adjustByDPI(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.adjustByDPI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_shrinkPortraitUI(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shrinkPortraitUI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_shrinkPortraitUI(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.shrinkPortraitUI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_constraint(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.constraint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activeScaling(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.activeScaling);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activeHeight(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activeHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pixelSizeAdjustment(IntPtr l) {
		try {
			UIRoot self=(UIRoot)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pixelSizeAdjustment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIRoot");
		addMember(l,GetPixelSizeAdjustment);
		addMember(l,UpdateScale);
		addMember(l,GetPixelSizeAdjustment_s);
		addMember(l,Broadcast_s);
		addMember(l,"list",get_list,set_list,false);
		addMember(l,"scalingStyle",get_scalingStyle,set_scalingStyle,true);
		addMember(l,"manualWidth",get_manualWidth,set_manualWidth,true);
		addMember(l,"manualHeight",get_manualHeight,set_manualHeight,true);
		addMember(l,"minimumHeight",get_minimumHeight,set_minimumHeight,true);
		addMember(l,"maximumHeight",get_maximumHeight,set_maximumHeight,true);
		addMember(l,"fitWidth",get_fitWidth,set_fitWidth,true);
		addMember(l,"fitHeight",get_fitHeight,set_fitHeight,true);
		addMember(l,"adjustByDPI",get_adjustByDPI,set_adjustByDPI,true);
		addMember(l,"shrinkPortraitUI",get_shrinkPortraitUI,set_shrinkPortraitUI,true);
		addMember(l,"constraint",get_constraint,null,true);
		addMember(l,"activeScaling",get_activeScaling,null,true);
		addMember(l,"activeHeight",get_activeHeight,null,true);
		addMember(l,"pixelSizeAdjustment",get_pixelSizeAdjustment,null,true);
		createTypeMetatable(l,null, typeof(UIRoot),typeof(UnityEngine.MonoBehaviour));
	}
}
