using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.IGO;

[CustomEditor(typeof(ClickableObject))]
public class ClickableObjectEditor : Editor {



	ClickableObject co;

	public override void OnInspectorGUI(){
		co = target as ClickableObject;
		co.choice = (ClickableObject.Choices)EditorGUILayout.EnumPopup("Type :",co.choice);
		if (co.choice == ClickableObject.Choices.Character)
		{
			CharacterGUI();
		}

		if (co.choice == ClickableObject.Choices.Item)
		{
			ItemGUI();
		}


	}


	void CharacterGUI(){
		
		if(GeneralValue.igoData.AllCharacters.Length != 0){
			string[] choice = GeneralValue.igoData.AllCharacters.GetAllNameIGO();

			co.doIndex = EditorGUILayout.Popup ("Character",co.doIndex,choice);
			DrawDefaultInspector();

			if(GUI.changed){
				co.displayedObject = GeneralValue.igoData.AllCharacters[co.doIndex];
				if(co.displayedObject != null){
					var _chara = (Character)co.displayedObject;
					co.GetComponent<Image>().sprite = _chara.objectSprite;
				}
				EditorUtility.SetDirty(target);
			}
		}
	
	}
	void ItemGUI(){
		
		if(GeneralValue.igoData.AllItems.Length != 0){
			string[] choice = GeneralValue.igoData.AllItems.GetAllNameIGO();

			co.doIndex = EditorGUILayout.Popup ("Item",co.doIndex,choice);
			DrawDefaultInspector();

			if(GUI.changed){
				co.displayedObject = GeneralValue.igoData.AllItems[co.doIndex];
				if(co.displayedObject != null){
					var _item = (Item)co.displayedObject;
					co.GetComponent<Image>().sprite = _item.objectSprite;
				}
				EditorUtility.SetDirty(target);
			}
		}

	}
		


}
