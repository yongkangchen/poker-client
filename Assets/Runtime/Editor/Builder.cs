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
