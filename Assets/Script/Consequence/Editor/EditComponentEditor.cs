using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.NotEditable;

/*[CustomEditor(typeof(EditComponent))]
[CanEditMultipleObjects]
public class EditComponentEditor : Editor {

	public override void OnInspectorGUI(){
			var editComp = target as EditComponent;
			int _targetIndex = editComp.targetIndex;
			string[] _choices = editComp.choices;
		
			DrawDefaultInspector();
			
			if (GUILayout.Button("Reset List")){
				
				var _tempChoices =  new List<string>();

				foreach (var c in editComp.gameObject.GetComponents<Component>())
				{
					var _compName = c.GetType().ToString();
					_compName = _compName.DeleteFirstWord(); 
					if(!_compName.IsAWordInAString("NotEditable")){
						_tempChoices.Add(_compName);

					}

				}
				editComp.choices = new string[_tempChoices.Count];
				for (int i = 0; i < _tempChoices.Count; i++)
				{
					editComp.choices[i] = _tempChoices[i];
				}

			}

			editComp.targetIndex = EditorGUILayout.Popup ("Target",_targetIndex,_choices);
			if (GUI.changed){
			// Update the selected choice in the underlying object
				editComp.target = _choices[_targetIndex];
			// Save the changes back to the object
				EditorUtility.SetDirty(target);
				EditorUtility.SetDirty(this);
			}
	}
}*/
