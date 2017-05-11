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
using UnityEditor;

public class TextureProcessor :AssetPostprocessor {

	void OnPreprocessTexture()
	{
		if (assetPath.Contains ("Resources/prefabs") && assetPath.EndsWith ("icon.png")) return;
		TextureImporter importer = assetImporter as TextureImporter;
		importer.textureType = TextureImporterType.Sprite;
		importer.mipmapEnabled = false;
	}

	[MenuItem("Assets/DisableAllMaipMap")]
	public static void DisableMipmap() {
		var guids = AssetDatabase.FindAssets("t:Texture2d");
		if(guids != null && guids.Length > 0)
		{
			TextureImporter importer = TextureImporter.GetAtPath(AssetDatabase.GUIDToAssetPath(guids[0])) as TextureImporter;
			if(importer.textureType == TextureImporterType.Sprite)
			{
				importer.mipmapEnabled = false;
			}
		}
	}

	[MenuItem("Assets/NewAltas", false, -1)]
	static public void CreateAltas()
	{
		GameObject parent = new GameObject ();
		foreach (UnityEngine.Object obj in Selection.objects) {
			var path = AssetDatabase.GetAssetPath(obj);
			var o = new GameObject();
			o.transform.SetParent(parent.transform, false);
			var render = o.AddComponent<SpriteRenderer>();
			render.sprite = AssetDatabase.LoadAssetAtPath(path, typeof(Sprite)) as Sprite;
			o.transform.name = render.sprite.name;
		}
	}
}
