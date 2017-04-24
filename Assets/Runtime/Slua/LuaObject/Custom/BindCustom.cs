using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
				Lua_SocketManager.reg,
				Lua_Util.reg,
				Lua_BehaviourEvent.reg,
				Lua_System_Collections_Generic_Dictionary_2_string_string.reg,
			};
			return list;
		}
	}
}
