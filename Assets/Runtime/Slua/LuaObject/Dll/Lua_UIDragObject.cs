using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIDragObject : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CancelMovement(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			self.CancelMovement();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CancelSpring(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			self.CancelSpring();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.target=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_panelRegion(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.panelRegion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_panelRegion(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UIPanel v;
			checkType(l,2,out v);
			self.panelRegion=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrollMomentum(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scrollMomentum);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrollMomentum(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.scrollMomentum=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_restrictWithinPanel(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.restrictWithinPanel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_restrictWithinPanel(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.restrictWithinPanel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_contentRect(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.contentRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_contentRect(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UIRect v;
			checkType(l,2,out v);
			self.contentRect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragEffect(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.dragEffect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragEffect(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UIDragObject.DragEffect v;
			checkEnum(l,2,out v);
			self.dragEffect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_momentumAmount(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.momentumAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_momentumAmount(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.momentumAmount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragMovement(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dragMovement);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dragMovement(IntPtr l) {
		try {
			UIDragObject self=(UIDragObject)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.dragMovement=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIDragObject");
		addMember(l,CancelMovement);
		addMember(l,CancelSpring);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"panelRegion",get_panelRegion,set_panelRegion,true);
		addMember(l,"scrollMomentum",get_scrollMomentum,set_scrollMomentum,true);
		addMember(l,"restrictWithinPanel",get_restrictWithinPanel,set_restrictWithinPanel,true);
		addMember(l,"contentRect",get_contentRect,set_contentRect,true);
		addMember(l,"dragEffect",get_dragEffect,set_dragEffect,true);
		addMember(l,"momentumAmount",get_momentumAmount,set_momentumAmount,true);
		addMember(l,"dragMovement",get_dragMovement,set_dragMovement,true);
		createTypeMetatable(l,null, typeof(UIDragObject),typeof(UnityEngine.MonoBehaviour));
	}
}
