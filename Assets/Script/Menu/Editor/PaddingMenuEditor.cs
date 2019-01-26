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
	private bool enableSet;

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
		if(padingMenuTarget.thisActiveChild == null)
		{
			padingMenuTarget.thisActiveChild = padingMenuTarget.GetComponent<ActiveChild>();	
		}

		//	
	}
	

	public override void OnInspectorGUI()
	{
		if(!enableSet)
		{
			SetVar();
			enableSet =true;
		}
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
		if(!SetMenuButtonGUI<ItemMenuButton>("CharaMenuButton"))
		{
			return;
		}
	}

	private void PersoGUI()
	{
		if(!SetMenuButtonGUI<CharaMenuButton>("CharaMenuButton"))
		{
			return;
		}

		
	}

	private void ObjGUI()
	{
		if(!SetMenuButtonGUI<ObjectiveMenuButton>("CharaMenuButton"))
		{
			return;
		}
	}

	private bool SetMenuButtonGUI<T>(string _Label) where T : IMenuButton
	{
		padingMenuTarget.menuButton = (GameObject) EditorGUILayout.ObjectField(_Label,padingMenuTarget.menuButton,typeof(GameObject),false);
		if(padingMenuTarget.menuButton == null){return false;}
		if(padingMenuTarget.menuButton.GetComponent<T>() == null)
		{
			padingMenuTarget.menuButton = null;
			return false;
		}
		return true;
	}

}
