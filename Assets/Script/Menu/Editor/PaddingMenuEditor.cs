using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using VolarelaNS.Menu;
using VolarelaNS.IGO;

[CustomEditor(typeof(PadingMenu))]
public class PadingMenuEditor : Editor 
{
	private PadingMenu padingMenuTarget;

	private void OnEnable ()
	{
		SetVar();
	}

	private void SetVar()
	{
		if(padingMenuTarget == null)
		{
			padingMenuTarget = target as PadingMenu;
		}
		if(padingMenuTarget.layoutGroup == null)
		{
			padingMenuTarget.layoutGroup = padingMenuTarget.gameObject.GetComponent<GridLayoutGroup>();
		}
		if(padingMenuTarget.self == null)
		{
			padingMenuTarget.self = padingMenuTarget.gameObject.GetComponent<RectTransform>();
		}
	}

	public override void OnInspectorGUI()
	{
		ReferenceGUI();
	}

	private void ReferenceGUI()
	{
		padingMenuTarget.padingType = (PadingType) EditorGUILayout.EnumPopup("Type of Pading", padingMenuTarget.padingType);
		switch (padingMenuTarget.padingType)
		{
			case PadingType.Item :
				ItemGUI();
				break;
			
			case PadingType.Perso :
				PersoGUI();
				break;
			
			case PadingType.Objectives :
				ObjGUI();
				break;
		}
	}

	private void ItemGUI()
	{
		SetMenuButtonGUI<CharaMenuButton>("CharaMenuButton");
	}

	private void PersoGUI()
	{

	}

	private void ObjGUI()
	{

	}

	private void SetMenuButtonGUI<T>(string _Label) where T : IMenuButton
	{
		padingMenuTarget.menuButton = (GameObject) EditorGUILayout.ObjectField(_Label,padingMenuTarget.menuButton,typeof(GameObject),false);
		if(padingMenuTarget.menuButton.GetComponent<T>() == null)
		{
			padingMenuTarget.menuButton = null;
		}
	}

	private void ClearChild()
	{
		foreach (Transform child in padingMenuTarget.self)
		{
			Destroy(child.gameObject);
		}
		/*
		foreach (var item in collection)
		{
			
		}
		 */
	}

}
