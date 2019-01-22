// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using VolarelaNS;
// using VolarelaNS.IGO;

// //[CustomEditor(typeof(CharactersDynamicAnimation))]
// public class CDAEditor : Editor {


// 	CharactersDynamicAnimation cda;
// 	public override void OnInspectorGUI(){
// 		cda = target as CharactersDynamicAnimation;

// 		if(GeneralValue.igoData.AllCharacters.Length != 0){
// 			string[] choice = GeneralValue.igoData.AllCharacters.GetAllNameIGO();

// 			cda.charaIndex = EditorGUILayout.Popup ("Character",cda.charaIndex,choice);
// 			DrawDefaultInspector();

// 			if(GUI.changed){
// 				//cda.defaultChara = GeneralValue.igoData.AllCharacters[cda.charaIndex];
// 				EditorUtility.SetDirty(target);
// 			}
// 		}
// 	}


// }
