/**
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
**/
﻿
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SLua;

public class Main : MonoBehaviour {
	#if UNITY_EDITOR
	public bool isLua = false;
	public UnityEditor.DefaultAsset mainFolder;
	#endif
	public bool isLobby = false;
	public string mainFolderString;

	public delegate void UnityTask();
	private static List<UnityTask> taskList = new List<UnityTask>();
	public static void runInUnityThread(UnityTask task)
	{
		lock(taskList)
		{
			taskList.Add(task);
		}
	}

	private LuaSvr svr;
	void Start () {
		LuaState.loaderDelegate = (string fn)=>{
			byte[] bytes = null;
			if(File.Exists(fn)){
				bytes = File.ReadAllBytes(fn);
			}
			else{
				fn = fn.Replace(".", "/");
				TextAsset asset = (TextAsset)Resources.Load(fn);

				if (asset == null)return null;
				bytes = asset.bytes;
			}
			return bytes;
		};

		svr = new LuaSvr();
		svr.init(null, () =>
		{
			#if UNITY_EDITOR
			if(mainFolder){
				svr.luaState.doString("MainFloder='" + mainFolder.name + "'");
			}
			svr.luaState.doString("IsLua=" + (isLua?"true":"false"));
			#else
			svr.luaState.doString("MainFloder='" + mainFolderString + "'");
			#endif
			svr.luaState.doString("IsLobby=" + (isLobby?"true":"false"));
			svr.start("start");
		});
	}

	void FixedUpdate ()
	{
		UnityTask[] arr = null;
		lock(taskList)
		{
			if(taskList.Count == 0) return;
			arr = taskList.ToArray();
			taskList.Clear();
		}

		foreach (UnityTask task in arr)
		{
			try{
				task();
			}catch(System.Exception e)
			{
				Debug.LogError(e);
			}
		}
	}

	void OnDestroy()
	{
		taskList.Clear ();
		SocketManager.dispose (true);
		// l.luaState.Dispose ();
	}
}
