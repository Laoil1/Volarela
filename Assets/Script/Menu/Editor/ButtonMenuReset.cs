using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS.Menu;

public class ButtonMenuReset
{
	[MenuItem("Volarela/ResetMenuButton")]
	public static void SetButtonMenu ()
	{
		var padMen = (PadingMenu[]) Resources.FindObjectsOfTypeAll(typeof(PadingMenu));
		if(padMen.Length == 0)
		{
			ErrorButtonMenuWindow.Init();
		}
		else
		{
			foreach (var pad in padMen)
			{
				pad.SetPadingMenu();
			}
		}
	}
}

public class ErrorButtonMenuWindow : EditorWindow
{
	private static EditorWindow win;
	public static void Init()
	{
		win = GetWindow(typeof(ErrorButtonMenuWindow),true,"ERROR",true);
		Vector2 size = new Vector2 (200.0f,80.0f);
		win.maxSize = size;
		win.minSize = size;
	}

	private void OnGUI()
	{
		EditorGUILayout.HelpBox("You Can't use this function, because there is no Menu Here", MessageType.Error);
		if(GUILayout.Button("OK",GUILayout.Width(30)))
		{
			win.Close();
		}
	}
}
