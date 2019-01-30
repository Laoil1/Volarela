using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GetPathOfAnObject : EditorWindow {

	
	private Object obj;

	[MenuItem("Utility/Get Path")]
	public static void Init ()
	{
		var win = EditorWindow.GetWindow(typeof(GetPathOfAnObject),true,"Get Path", true);
		
		Vector2 _size = new Vector2(450,45);
		win.maxSize = _size;
		win.minSize = _size;
		
		win.Show();

	}

	public void OnGUI()
	{
		obj = EditorGUILayout.ObjectField("Object", obj, typeof(Object),false);
		if(obj == null)
		{
			EditorGUILayout.LabelField("There is no object Selected");
		}
		else
		{
			string path = AssetDatabase.GetAssetPath(obj);
			EditorGUILayout.TextField("Your Object Path is : ", path);
		}
	}
}
