using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS.EventVol;
using VolarelaNS.IGO;
using VolarelaNS;

[CustomEditor(typeof(DiscoverCharacter))]
public class DiscoverCharacterEditor : Editor {


	DiscoverCharacter dc;

	public void OnEnable()
	{
		dc = target as DiscoverCharacter;
	}

	public override void OnInspectorGUI(){
		dc.igoType = (IGOChoices)EditorGUILayout.EnumPopup("Type :",dc.igoType);
		if (dc.igoType == IGOChoices.Character)
		{
			CharacterGUI();
		}

		if (dc.igoType == IGOChoices.Item)
		{
			ItemGUI();
		}

		
		if (dc.igoType == IGOChoices.Goal)
		{
			GoalGUI();
		}



	}


	private void CharacterGUI(){
		if(GeneralValue.igoData.AllCharacters.Length != 0){
			string[] choice = GeneralValue.igoData.AllCharacters.GetAllNameIGO();

			dc.coIndex = EditorGUILayout.Popup ("Character",dc.coIndex,choice);

			if(GUI.changed){
				dc.changerdObject = dc.coIndex;
				EditorUtility.SetDirty(target);
			}
		}
	
	}
	private void ItemGUI(){
		
		if(GeneralValue.igoData.AllItems.Length != 0){
			string[] choice = GeneralValue.igoData.AllItems.GetAllNameIGO();

			dc.coIndex = EditorGUILayout.Popup ("Item",dc.coIndex,choice);

			if(GUI.changed){
				dc.changerdObject = dc.coIndex;
				EditorUtility.SetDirty(target);
			}
		}

	}

	private void GoalGUI(){
		
		if(GeneralValue.igoData.AllGoals.Length != 0){
			string[] choice = GeneralValue.igoData.AllGoals.GetAllNameIGO();

			dc.coIndex = EditorGUILayout.Popup ("Goal",dc.coIndex,choice);

			if(GUI.changed){
				dc.changerdObject = dc.coIndex;
				EditorUtility.SetDirty(target);
			}
		}

	}
}
