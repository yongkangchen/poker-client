using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UIPopupList : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UIPopupList o;
			o=new UIPopupList();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Set(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.Set(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddItem(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UIPopupList self=(UIPopupList)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.AddItem(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UIPopupList self=(UIPopupList)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.AddItem(a1,a2);
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
	static public int RemoveItem(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.RemoveItem(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveItemByData(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.RemoveItemByData(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Start(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			self.Start();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CloseSelf(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			self.CloseSelf();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Show(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			self.Show();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Close_s(IntPtr l) {
		try {
			UIPopupList.Close();
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
			pushValue(l,UIPopupList.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_current(IntPtr l) {
		try {
			UIPopupList v;
			checkType(l,2,out v);
			UIPopupList.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_atlas(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.atlas);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_atlas(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UIAtlas v;
			checkType(l,2,out v);
			self.atlas=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_bitmapFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bitmapFont);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_bitmapFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UIFont v;
			checkType(l,2,out v);
			self.bitmapFont=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_trueTypeFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.trueTypeFont);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_trueTypeFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Font v;
			checkType(l,2,out v);
			self.trueTypeFont=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fontSize(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fontSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fontSize(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.fontSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fontStyle(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.fontStyle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fontStyle(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.FontStyle v;
			checkEnum(l,2,out v);
			self.fontStyle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_backgroundSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.backgroundSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_backgroundSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.backgroundSprite=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_highlightSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highlightSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_highlightSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.highlightSprite=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_background2DSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.background2DSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_background2DSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.background2DSprite=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_highlight2DSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highlight2DSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_highlight2DSprite(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.highlight2DSprite=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_position(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_position(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UIPopupList.Position v;
			checkEnum(l,2,out v);
			self.position=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alignment(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.alignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alignment(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			NGUIText.Alignment v;
			checkEnum(l,2,out v);
			self.alignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_items(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.items);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_items(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Collections.Generic.List<System.String> v;
			checkType(l,2,out v);
			self.items=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_itemData(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.itemData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_itemData(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Collections.Generic.List<System.Object> v;
			checkType(l,2,out v);
			self.itemData=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_padding(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.padding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_padding(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.padding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_textColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.textColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_textColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.textColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_backgroundColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.backgroundColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_backgroundColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.backgroundColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_highlightColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highlightColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_highlightColor(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.highlightColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isAnimated(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isAnimated);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isAnimated(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isAnimated=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isLocalized(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isLocalized);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isLocalized(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isLocalized=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_separatePanel(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.separatePanel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_separatePanel(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.separatePanel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_openOn(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.openOn);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_openOn(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UIPopupList.OpenOn v;
			checkEnum(l,2,out v);
			self.openOn=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_onChange(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onChange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onChange(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			System.Collections.Generic.List<EventDelegate> v;
			checkType(l,2,out v);
			self.onChange=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startingPosition(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startingPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startingPosition(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.startingPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_source(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.source);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_source(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.source=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ambigiousFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ambigiousFont);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ambigiousFont(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			UnityEngine.Object v;
			checkType(l,2,out v);
			self.ambigiousFont=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isOpen(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UIPopupList.isOpen);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_value(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_value(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.value=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_data(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.data);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isColliderEnabled(IntPtr l) {
		try {
			UIPopupList self=(UIPopupList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isColliderEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UIPopupList");
		addMember(l,Set);
		addMember(l,Clear);
		addMember(l,AddItem);
		addMember(l,RemoveItem);
		addMember(l,RemoveItemByData);
		addMember(l,Start);
		addMember(l,CloseSelf);
		addMember(l,Show);
		addMember(l,Close_s);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"atlas",get_atlas,set_atlas,true);
		addMember(l,"bitmapFont",get_bitmapFont,set_bitmapFont,true);
		addMember(l,"trueTypeFont",get_trueTypeFont,set_trueTypeFont,true);
		addMember(l,"fontSize",get_fontSize,set_fontSize,true);
		addMember(l,"fontStyle",get_fontStyle,set_fontStyle,true);
		addMember(l,"backgroundSprite",get_backgroundSprite,set_backgroundSprite,true);
		addMember(l,"highlightSprite",get_highlightSprite,set_highlightSprite,true);
		addMember(l,"background2DSprite",get_background2DSprite,set_background2DSprite,true);
		addMember(l,"highlight2DSprite",get_highlight2DSprite,set_highlight2DSprite,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"items",get_items,set_items,true);
		addMember(l,"itemData",get_itemData,set_itemData,true);
		addMember(l,"padding",get_padding,set_padding,true);
		addMember(l,"textColor",get_textColor,set_textColor,true);
		addMember(l,"backgroundColor",get_backgroundColor,set_backgroundColor,true);
		addMember(l,"highlightColor",get_highlightColor,set_highlightColor,true);
		addMember(l,"isAnimated",get_isAnimated,set_isAnimated,true);
		addMember(l,"isLocalized",get_isLocalized,set_isLocalized,true);
		addMember(l,"separatePanel",get_separatePanel,set_separatePanel,true);
		addMember(l,"openOn",get_openOn,set_openOn,true);
		addMember(l,"onChange",get_onChange,set_onChange,true);
		addMember(l,"startingPosition",get_startingPosition,set_startingPosition,true);
		addMember(l,"source",get_source,set_source,true);
		addMember(l,"ambigiousFont",get_ambigiousFont,set_ambigiousFont,true);
		addMember(l,"isOpen",get_isOpen,null,false);
		addMember(l,"value",get_value,set_value,true);
		addMember(l,"data",get_data,null,true);
		addMember(l,"isColliderEnabled",get_isColliderEnabled,null,true);
		createTypeMetatable(l,constructor, typeof(UIPopupList),typeof(UIWidgetContainer));
	}
}
