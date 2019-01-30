// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using UnityEditor.SceneManagement;
// using VolarelaNS;

// [CustomEditor(typeof(SomeClass))]
// public class SomeEditor : Editor
// {	
	
// 	public override void OnInspectorGUI ()
// 	{		
// 			var someClass = target as SomeClass;
// 			int _choiceIndex = someClass.index;
// 			DrawDefaultInspector();
// 			string[] _choices = new string[]{"g","i","k"};
// 			someClass.index = EditorGUILayout.Popup ("choice",_choiceIndex,_choices);
// 			//string[] _choices = SwitchInUse.GetSwitchData("IBakedYouAPIe").GetAllSwitchName();
// 			if (GUI.changed){
// 				// Update the selected choice in the underlying object
// 				someClass.choice.name = _choices[_choiceIndex];
// 			// Save the changes back to the object
// 				EditorUtility.SetDirty(target);
// 				EditorUtility.SetDirty(this);
// 				EditorSceneManager.MarkSceneDirty(someClass.gameObject.scene);
// 			}
// 	}

// }
