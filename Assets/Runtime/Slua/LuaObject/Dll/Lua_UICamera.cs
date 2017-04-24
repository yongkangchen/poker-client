using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UICamera : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessMouse(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			self.ProcessMouse();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessTouches(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			self.ProcessTouches();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessOthers(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			self.ProcessOthers();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ProcessTouch(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.ProcessTouch(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPressed_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UICamera.IsPressed(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CountInputSources_s(IntPtr l) {
		try {
			var ret=UICamera.CountInputSources();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Raycast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector3))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				var ret=UICamera.Raycast(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UICamera.MouseOrTouch))){
				UICamera.MouseOrTouch a1;
				checkType(l,1,out a1);
				UICamera.Raycast(a1);
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
	static public int IsHighlighted_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UICamera.IsHighlighted(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindCameraForLayer_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UICamera.FindCameraForLayer(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Notify_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Object a3;
			checkType(l,3,out a3);
			UICamera.Notify(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CancelNextTooltip_s(IntPtr l) {
		try {
			UICamera.CancelNextTooltip();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ShowTooltip_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UICamera.ShowTooltip(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int HideTooltip_s(IntPtr l) {
		try {
			var ret=UICamera.HideTooltip();
			pushValue(l,true);
			pushValue(l,ret);
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
			pushValue(l,UICamera.list);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_list(IntPtr l) {
		try {
			BetterList<UICamera> v;
			checkType(l,2,out v);
			UICamera.list=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetKeyDown(IntPtr l) {
		try {
			UICamera.GetKeyStateFunc v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetKeyDown=v;
			else if(op==1) UICamera.GetKeyDown+=v;
			else if(op==2) UICamera.GetKeyDown-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetKeyUp(IntPtr l) {
		try {
			UICamera.GetKeyStateFunc v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetKeyUp=v;
			else if(op==1) UICamera.GetKeyUp+=v;
			else if(op==2) UICamera.GetKeyUp-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetKey(IntPtr l) {
		try {
			UICamera.GetKeyStateFunc v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetKey=v;
			else if(op==1) UICamera.GetKey+=v;
			else if(op==2) UICamera.GetKey-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetAxis(IntPtr l) {
		try {
			UICamera.GetAxisFunc v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetAxis=v;
			else if(op==1) UICamera.GetAxis+=v;
			else if(op==2) UICamera.GetAxis-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetAnyKeyDown(IntPtr l) {
		try {
			UICamera.GetAnyKeyFunc v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetAnyKeyDown=v;
			else if(op==1) UICamera.GetAnyKeyDown+=v;
			else if(op==2) UICamera.GetAnyKeyDown-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetMouse(IntPtr l) {
		try {
			UICamera.GetMouseDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetMouse=v;
			else if(op==1) UICamera.GetMouse+=v;
			else if(op==2) UICamera.GetMouse-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetTouch(IntPtr l) {
		try {
			UICamera.GetTouchDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetTouch=v;
			else if(op==1) UICamera.GetTouch+=v;
			else if(op==2) UICamera.GetTouch-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RemoveTouch(IntPtr l) {
		try {
			UICamera.RemoveTouchDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.RemoveTouch=v;
			else if(op==1) UICamera.RemoveTouch+=v;
			else if(op==2) UICamera.RemoveTouch-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onScreenResize(IntPtr l) {
		try {
			UICamera.OnScreenResize v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onScreenResize=v;
			else if(op==1) UICamera.onScreenResize+=v;
			else if(op==2) UICamera.onScreenResize-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventType(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.eventType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_eventType(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UICamera.EventType v;
			checkEnum(l,2,out v);
			self.eventType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventsGoToColliders(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eventsGoToColliders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_eventsGoToColliders(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.eventsGoToColliders=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventReceiverMask(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eventReceiverMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_eventReceiverMask(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UnityEngine.LayerMask v;
			checkValueType(l,2,out v);
			self.eventReceiverMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_processEventsIn(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.processEventsIn);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_processEventsIn(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UICamera.ProcessEventsIn v;
			checkEnum(l,2,out v);
			self.processEventsIn=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_debug(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.debug);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_debug(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.debug=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useMouse(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useMouse);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useMouse(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useMouse=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useTouch(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useTouch);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useTouch(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useTouch=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_allowMultiTouch(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.allowMultiTouch);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_allowMultiTouch(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.allowMultiTouch=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useKeyboard(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useKeyboard);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useKeyboard(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useKeyboard=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useController(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useController);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useController(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useController=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_stickyTooltip(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.stickyTooltip);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_stickyTooltip(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.stickyTooltip=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tooltipDelay(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tooltipDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_tooltipDelay(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.tooltipDelay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_longPressTooltip(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.longPressTooltip);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_longPressTooltip(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.longPressTooltip=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mouseDragThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mouseDragThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mouseDragThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.mouseDragThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mouseClickThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mouseClickThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mouseClickThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.mouseClickThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_touchDragThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchDragThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_touchDragThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.touchDragThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_touchClickThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchClickThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_touchClickThreshold(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.touchClickThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rangeDistance(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rangeDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_rangeDistance(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.rangeDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontalAxisName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.horizontalAxisName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verticalAxisName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.verticalAxisName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_horizontalPanAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.horizontalPanAxisName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_horizontalPanAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.horizontalPanAxisName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_verticalPanAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.verticalPanAxisName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_verticalPanAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.verticalPanAxisName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrollAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scrollAxisName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrollAxisName(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.scrollAxisName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_commandClick(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.commandClick);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_commandClick(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.commandClick=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_submitKey0(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.submitKey0);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_submitKey0(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.submitKey0=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_submitKey1(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.submitKey1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_submitKey1(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.submitKey1=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cancelKey0(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.cancelKey0);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cancelKey0(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.cancelKey0=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cancelKey1(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.cancelKey1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cancelKey1(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			self.cancelKey1=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_autoHideCursor(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autoHideCursor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_autoHideCursor(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.autoHideCursor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onCustomInput(IntPtr l) {
		try {
			UICamera.OnCustomInput v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onCustomInput=v;
			else if(op==1) UICamera.onCustomInput+=v;
			else if(op==2) UICamera.onCustomInput-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showTooltips(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.showTooltips);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showTooltips(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			UICamera.showTooltips=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ignoreControllerInput(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.ignoreControllerInput);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ignoreControllerInput(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			UICamera.ignoreControllerInput=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lastWorldPosition(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.lastWorldPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lastWorldPosition(IntPtr l) {
		try {
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			UICamera.lastWorldPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lastHit(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.lastHit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lastHit(IntPtr l) {
		try {
			UnityEngine.RaycastHit v;
			checkValueType(l,2,out v);
			UICamera.lastHit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			UICamera v;
			checkType(l,2,out v);
			UICamera.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentCamera(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.currentCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentCamera(IntPtr l) {
		try {
			UnityEngine.Camera v;
			checkType(l,2,out v);
			UICamera.currentCamera=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onSchemeChange(IntPtr l) {
		try {
			UICamera.OnSchemeChange v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onSchemeChange=v;
			else if(op==1) UICamera.onSchemeChange+=v;
			else if(op==2) UICamera.onSchemeChange-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentTouchID(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.currentTouchID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentTouchID(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			UICamera.currentTouchID=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentTouch(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.currentTouch);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentTouch(IntPtr l) {
		try {
			UICamera.MouseOrTouch v;
			checkType(l,2,out v);
			UICamera.currentTouch=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fallThrough(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.fallThrough);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fallThrough(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			UICamera.fallThrough=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onClick(IntPtr l) {
		try {
			UICamera.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onClick=v;
			else if(op==1) UICamera.onClick+=v;
			else if(op==2) UICamera.onClick-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDoubleClick(IntPtr l) {
		try {
			UICamera.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDoubleClick=v;
			else if(op==1) UICamera.onDoubleClick+=v;
			else if(op==2) UICamera.onDoubleClick-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onHover(IntPtr l) {
		try {
			UICamera.BoolDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onHover=v;
			else if(op==1) UICamera.onHover+=v;
			else if(op==2) UICamera.onHover-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onPress(IntPtr l) {
		try {
			UICamera.BoolDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onPress=v;
			else if(op==1) UICamera.onPress+=v;
			else if(op==2) UICamera.onPress-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onSelect(IntPtr l) {
		try {
			UICamera.BoolDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onSelect=v;
			else if(op==1) UICamera.onSelect+=v;
			else if(op==2) UICamera.onSelect-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onScroll(IntPtr l) {
		try {
			UICamera.FloatDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onScroll=v;
			else if(op==1) UICamera.onScroll+=v;
			else if(op==2) UICamera.onScroll-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDrag(IntPtr l) {
		try {
			UICamera.VectorDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDrag=v;
			else if(op==1) UICamera.onDrag+=v;
			else if(op==2) UICamera.onDrag-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDragStart(IntPtr l) {
		try {
			UICamera.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDragStart=v;
			else if(op==1) UICamera.onDragStart+=v;
			else if(op==2) UICamera.onDragStart-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDragOver(IntPtr l) {
		try {
			UICamera.ObjectDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDragOver=v;
			else if(op==1) UICamera.onDragOver+=v;
			else if(op==2) UICamera.onDragOver-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDragOut(IntPtr l) {
		try {
			UICamera.ObjectDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDragOut=v;
			else if(op==1) UICamera.onDragOut+=v;
			else if(op==2) UICamera.onDragOut-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDragEnd(IntPtr l) {
		try {
			UICamera.VoidDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDragEnd=v;
			else if(op==1) UICamera.onDragEnd+=v;
			else if(op==2) UICamera.onDragEnd-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onDrop(IntPtr l) {
		try {
			UICamera.ObjectDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onDrop=v;
			else if(op==1) UICamera.onDrop+=v;
			else if(op==2) UICamera.onDrop-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onKey(IntPtr l) {
		try {
			UICamera.KeyCodeDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onKey=v;
			else if(op==1) UICamera.onKey+=v;
			else if(op==2) UICamera.onKey-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onNavigate(IntPtr l) {
		try {
			UICamera.KeyCodeDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onNavigate=v;
			else if(op==1) UICamera.onNavigate+=v;
			else if(op==2) UICamera.onNavigate-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onPan(IntPtr l) {
		try {
			UICamera.VectorDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onPan=v;
			else if(op==1) UICamera.onPan+=v;
			else if(op==2) UICamera.onPan-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onTooltip(IntPtr l) {
		try {
			UICamera.BoolDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onTooltip=v;
			else if(op==1) UICamera.onTooltip+=v;
			else if(op==2) UICamera.onTooltip-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onMouseMove(IntPtr l) {
		try {
			UICamera.MoveDelegate v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.onMouseMove=v;
			else if(op==1) UICamera.onMouseMove+=v;
			else if(op==2) UICamera.onMouseMove-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_controller(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.controller);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_controller(IntPtr l) {
		try {
			UICamera.MouseOrTouch v;
			checkType(l,2,out v);
			UICamera.controller=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_activeTouches(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.activeTouches);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_activeTouches(IntPtr l) {
		try {
			System.Collections.Generic.List<UICamera.MouseOrTouch> v;
			checkType(l,2,out v);
			UICamera.activeTouches=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isDragging(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.isDragging);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isDragging(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			UICamera.isDragging=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetInputTouchCount(IntPtr l) {
		try {
			UICamera.GetTouchCountCallback v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetInputTouchCount=v;
			else if(op==1) UICamera.GetInputTouchCount+=v;
			else if(op==2) UICamera.GetInputTouchCount-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_GetInputTouch(IntPtr l) {
		try {
			UICamera.GetTouchCallback v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) UICamera.GetInputTouch=v;
			else if(op==1) UICamera.GetInputTouch+=v;
			else if(op==2) UICamera.GetInputTouch-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_disableController(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.disableController);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_disableController(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UICamera.disableController=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lastEventPosition(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.lastEventPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lastEventPosition(IntPtr l) {
		try {
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			UICamera.lastEventPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_first(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.first);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentScheme(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UICamera.currentScheme);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentScheme(IntPtr l) {
		try {
			UICamera.ControlScheme v;
			checkEnum(l,2,out v);
			UICamera.currentScheme=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentKey(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UICamera.currentKey);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_currentKey(IntPtr l) {
		try {
			UnityEngine.KeyCode v;
			checkEnum(l,2,out v);
			UICamera.currentKey=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_currentRay(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.currentRay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inputHasFocus(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.inputHasFocus);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cachedCamera(IntPtr l) {
		try {
			UICamera self=(UICamera)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cachedCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_tooltipObject(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.tooltipObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isOverUI(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.isOverUI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hoveredObject(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.hoveredObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hoveredObject(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			UICamera.hoveredObject=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_controllerNavigationObject(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.controllerNavigationObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_controllerNavigationObject(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			UICamera.controllerNavigationObject=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_selectedObject(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.selectedObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_selectedObject(IntPtr l) {
		try {
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			UICamera.selectedObject=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dragCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.dragCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mainCamera(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.mainCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_eventHandler(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UICamera.eventHandler);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UICamera");
		addMember(l,ProcessMouse);
		addMember(l,ProcessTouches);
		addMember(l,ProcessOthers);
		addMember(l,ProcessTouch);
		addMember(l,IsPressed_s);
		addMember(l,CountInputSources_s);
		addMember(l,Raycast_s);
		addMember(l,IsHighlighted_s);
		addMember(l,FindCameraForLayer_s);
		addMember(l,Notify_s);
		addMember(l,CancelNextTooltip_s);
		addMember(l,ShowTooltip_s);
		addMember(l,HideTooltip_s);
		addMember(l,"list",get_list,set_list,false);
		addMember(l,"GetKeyDown",null,set_GetKeyDown,false);
		addMember(l,"GetKeyUp",null,set_GetKeyUp,false);
		addMember(l,"GetKey",null,set_GetKey,false);
		addMember(l,"GetAxis",null,set_GetAxis,false);
		addMember(l,"GetAnyKeyDown",null,set_GetAnyKeyDown,false);
		addMember(l,"GetMouse",null,set_GetMouse,false);
		addMember(l,"GetTouch",null,set_GetTouch,false);
		addMember(l,"RemoveTouch",null,set_RemoveTouch,false);
		addMember(l,"onScreenResize",null,set_onScreenResize,false);
		addMember(l,"eventType",get_eventType,set_eventType,true);
		addMember(l,"eventsGoToColliders",get_eventsGoToColliders,set_eventsGoToColliders,true);
		addMember(l,"eventReceiverMask",get_eventReceiverMask,set_eventReceiverMask,true);
		addMember(l,"processEventsIn",get_processEventsIn,set_processEventsIn,true);
		addMember(l,"debug",get_debug,set_debug,true);
		addMember(l,"useMouse",get_useMouse,set_useMouse,true);
		addMember(l,"useTouch",get_useTouch,set_useTouch,true);
		addMember(l,"allowMultiTouch",get_allowMultiTouch,set_allowMultiTouch,true);
		addMember(l,"useKeyboard",get_useKeyboard,set_useKeyboard,true);
		addMember(l,"useController",get_useController,set_useController,true);
		addMember(l,"stickyTooltip",get_stickyTooltip,set_stickyTooltip,true);
		addMember(l,"tooltipDelay",get_tooltipDelay,set_tooltipDelay,true);
		addMember(l,"longPressTooltip",get_longPressTooltip,set_longPressTooltip,true);
		addMember(l,"mouseDragThreshold",get_mouseDragThreshold,set_mouseDragThreshold,true);
		addMember(l,"mouseClickThreshold",get_mouseClickThreshold,set_mouseClickThreshold,true);
		addMember(l,"touchDragThreshold",get_touchDragThreshold,set_touchDragThreshold,true);
		addMember(l,"touchClickThreshold",get_touchClickThreshold,set_touchClickThreshold,true);
		addMember(l,"rangeDistance",get_rangeDistance,set_rangeDistance,true);
		addMember(l,"horizontalAxisName",get_horizontalAxisName,set_horizontalAxisName,true);
		addMember(l,"verticalAxisName",get_verticalAxisName,set_verticalAxisName,true);
		addMember(l,"horizontalPanAxisName",get_horizontalPanAxisName,set_horizontalPanAxisName,true);
		addMember(l,"verticalPanAxisName",get_verticalPanAxisName,set_verticalPanAxisName,true);
		addMember(l,"scrollAxisName",get_scrollAxisName,set_scrollAxisName,true);
		addMember(l,"commandClick",get_commandClick,set_commandClick,true);
		addMember(l,"submitKey0",get_submitKey0,set_submitKey0,true);
		addMember(l,"submitKey1",get_submitKey1,set_submitKey1,true);
		addMember(l,"cancelKey0",get_cancelKey0,set_cancelKey0,true);
		addMember(l,"cancelKey1",get_cancelKey1,set_cancelKey1,true);
		addMember(l,"autoHideCursor",get_autoHideCursor,set_autoHideCursor,true);
		addMember(l,"onCustomInput",null,set_onCustomInput,false);
		addMember(l,"showTooltips",get_showTooltips,set_showTooltips,false);
		addMember(l,"ignoreControllerInput",get_ignoreControllerInput,set_ignoreControllerInput,false);
		addMember(l,"lastWorldPosition",get_lastWorldPosition,set_lastWorldPosition,false);
		addMember(l,"lastHit",get_lastHit,set_lastHit,false);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"currentCamera",get_currentCamera,set_currentCamera,false);
		addMember(l,"onSchemeChange",null,set_onSchemeChange,false);
		addMember(l,"currentTouchID",get_currentTouchID,set_currentTouchID,false);
		addMember(l,"currentTouch",get_currentTouch,set_currentTouch,false);
		addMember(l,"fallThrough",get_fallThrough,set_fallThrough,false);
		addMember(l,"onClick",null,set_onClick,false);
		addMember(l,"onDoubleClick",null,set_onDoubleClick,false);
		addMember(l,"onHover",null,set_onHover,false);
		addMember(l,"onPress",null,set_onPress,false);
		addMember(l,"onSelect",null,set_onSelect,false);
		addMember(l,"onScroll",null,set_onScroll,false);
		addMember(l,"onDrag",null,set_onDrag,false);
		addMember(l,"onDragStart",null,set_onDragStart,false);
		addMember(l,"onDragOver",null,set_onDragOver,false);
		addMember(l,"onDragOut",null,set_onDragOut,false);
		addMember(l,"onDragEnd",null,set_onDragEnd,false);
		addMember(l,"onDrop",null,set_onDrop,false);
		addMember(l,"onKey",null,set_onKey,false);
		addMember(l,"onNavigate",null,set_onNavigate,false);
		addMember(l,"onPan",null,set_onPan,false);
		addMember(l,"onTooltip",null,set_onTooltip,false);
		addMember(l,"onMouseMove",null,set_onMouseMove,false);
		addMember(l,"controller",get_controller,set_controller,false);
		addMember(l,"activeTouches",get_activeTouches,set_activeTouches,false);
		addMember(l,"isDragging",get_isDragging,set_isDragging,false);
		addMember(l,"GetInputTouchCount",null,set_GetInputTouchCount,false);
		addMember(l,"GetInputTouch",null,set_GetInputTouch,false);
		addMember(l,"disableController",get_disableController,set_disableController,false);
		addMember(l,"lastEventPosition",get_lastEventPosition,set_lastEventPosition,false);
		addMember(l,"first",get_first,null,false);
		addMember(l,"currentScheme",get_currentScheme,set_currentScheme,false);
		addMember(l,"currentKey",get_currentKey,set_currentKey,false);
		addMember(l,"currentRay",get_currentRay,null,false);
		addMember(l,"inputHasFocus",get_inputHasFocus,null,false);
		addMember(l,"cachedCamera",get_cachedCamera,null,true);
		addMember(l,"tooltipObject",get_tooltipObject,null,false);
		addMember(l,"isOverUI",get_isOverUI,null,false);
		addMember(l,"hoveredObject",get_hoveredObject,set_hoveredObject,false);
		addMember(l,"controllerNavigationObject",get_controllerNavigationObject,set_controllerNavigationObject,false);
		addMember(l,"selectedObject",get_selectedObject,set_selectedObject,false);
		addMember(l,"dragCount",get_dragCount,null,false);
		addMember(l,"mainCamera",get_mainCamera,null,false);
		addMember(l,"eventHandler",get_eventHandler,null,false);
		createTypeMetatable(l,null, typeof(UICamera),typeof(UnityEngine.MonoBehaviour));
	}
}
