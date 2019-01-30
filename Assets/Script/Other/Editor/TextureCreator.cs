using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TextureCreator : EditorWindow {

	
	private string texName = "tex0";
	private Color texColor;
	private Texture2D texture;

	
	[MenuItem("Utility/Texture Creator")]
	public static void Init ()
	{
		var win = EditorWindow.GetWindow(typeof(TextureCreator),true,"Texture Creator", true);
		
		Vector2 _size = new Vector2(300,80);
		win.maxSize = _size;
		win.minSize = _size;
		
		win.Show();

	}

	public void OnGUI()
	{
		texName = EditorGUILayout.TextField("Name", texName);
		texColor = EditorGUILayout.ColorField("Color", texColor);
		
		if(GUILayout.Button("Create"))
		{
			Texture2D texture = UsualFunction.MakeTex(100,100,texColor);
			var yes = texture.EncodeToPNG();
			File.WriteAllBytes("Assets/Resources/EditorTextures/" + texName + ".png",yes);
			AssetDatabase.Refresh();
		}
	}
}
