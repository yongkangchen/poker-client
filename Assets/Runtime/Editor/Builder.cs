/**
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
**/

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;


public class Builder
{
	[MenuItem("Assets/Export Lua")]
	public static void BuildLua()
	{
		SLua.LuaState l = new SLua.LuaState ();
		foreach (string file in Directory.GetFiles(Path.GetFullPath(Application.dataPath), "*.lua", SearchOption.AllDirectories))
		{
			if (file.StartsWith(Path.GetFullPath(Application.streamingAssetsPath)))
				continue;
			string output = file.Replace (Path.GetFullPath(Application.dataPath), "");
			output = Application.streamingAssetsPath + output;

			output = Path.GetFullPath(output);

			//Debug.LogError(Path.GetDirectoryName(output));

			Directory.CreateDirectory(Path.GetDirectoryName(output));

			l.doString(string.Format(@"
                                local f = io.open('{0}', 'wb')
                                local s = io.open('{1}')
                                f:write(string.dump(loadstring(s:read('*a'), '{1}')))
                                f:close()
                                s:close()
                        ", output.Replace(@"\", @"/"), file.Replace(@"\", @"/")));
		}

		l.Dispose ();
		AssetDatabase.Refresh ();
	}


	[PostProcessSceneAttribute]
	private static void onPostProcessBuildPlayer()
	{
		if (Application.isPlaying) return;
		var main = GameObject.Find("Main").GetComponent<Main>();
		main.mainFolderString = main.mainFolder.name;
		EditorApplication.SaveScene ();
		if (Debug.isDebugBuild) return;
		BuildLua ();
	}

}
