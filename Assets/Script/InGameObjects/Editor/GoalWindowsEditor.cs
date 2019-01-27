using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.IGO;


public class GoalWindows : EditorWindow {

	string[] allGoalName;
	Goal currentGoal;

	int goalIndex = 0;

	//Initialisation
	[MenuItem("Volarela/IGO/Goals")]
	static void Init()
	{
		EditorWindow window = GetWindow(typeof(GoalWindows),false,"GoalsManager"); 
		window.Show();
	}

	void OnGUI (){
		if(GeneralValue.igoData.AllGoals == null){
			CreateNewGoalGUI();
		}else{
			ThereIsItemGUI();
		}
		if (GUI.changed) 
		{
			EditorUtility.SetDirty(GeneralValue.igoData);
		}
	}

	void ThereIsItemGUI (){
		allGoalName = new string [GeneralValue.igoData.AllGoals.Length + 1];
		for (int i = 0; i < GeneralValue.igoData.AllGoals.Length; i++)
		{
			allGoalName[i] = GeneralValue.igoData.AllGoals[i].name;
		}
		allGoalName[allGoalName.Length-1] = "New Goal";
		goalIndex = EditorGUILayout.Popup(goalIndex, allGoalName);

		if(goalIndex == allGoalName.Length-1){
			CreateNewGoalGUI();
		}else{
			CommonGUI();
		}
	}

    void CommonGUI(){
		currentGoal = GeneralValue.igoData.AllGoals[goalIndex];
		
		if(GUILayout.Button("Delete"))
		{
			GeneralValue.igoData.AllGoals = GeneralValue.igoData.AllGoals.RemoveElement(goalIndex);
			return;
		}
        InformationsGUI();

		if(GUI.changed){
			EditorUtility.SetDirty(this);
		}
	}


	string _tempName;
	void CreateNewGoalGUI(){
		_tempName = EditorGUILayout.TextField("Name : ",_tempName);

		if(GUILayout.Button("Create New Goal")){
			if(GeneralValue.igoData.AllGoals!=null){
				var _item = GeneralValue.igoData.AllGoals;
				GeneralValue.igoData.AllGoals = new Goal [GeneralValue.igoData.AllGoals.Length+1];
				for (int i = 0; i < _item.Length; i++)
				{	
					GeneralValue.igoData.AllGoals[i] = _item[i];
				}
				GeneralValue.igoData.AllGoals[GeneralValue.igoData.AllGoals.Length-1] = new Goal(_tempName);
			}else{
				GeneralValue.igoData.AllGoals = new Goal[] {new Goal(_tempName)};
			}
		}
	}

	Vector2 scroll;
	//Description GUI
	void InformationsGUI(){
		GUILayout.Label("Information",EditorStyles.boldLabel);
		currentGoal.name = EditorGUILayout.TextField("Name : ",currentGoal.name);
		GUILayout.Label("Description :");
		scroll = EditorGUILayout.BeginScrollView(scroll);
		currentGoal.description = EditorGUILayout.TextArea(currentGoal.description,GUILayout.Height(100));
        EditorGUILayout.EndScrollView();
	}
}

