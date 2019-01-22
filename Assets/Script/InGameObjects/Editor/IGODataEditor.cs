using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;

[CustomEditor(typeof(IGOData))]
public class IGODataEditor : Editor {

	bool _debug;
	 public override void OnInspectorGUI (){

		_debug = EditorGUILayout.Toggle("DebugMode :",_debug);

		if(_debug){
			DrawDefaultInspector();
		}else{

			EditorGUILayout.LabelField ("Do not toutch or deplace if you want more infos, enter in debug mode");
		}

	}
	
}
