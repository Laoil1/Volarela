using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.IGO;


public class ItemWindows : EditorWindow {

	string[] allItemName;
	Item currentItem;

	int itemIndex = 0;

	//Initialisation
	[MenuItem("Volarela/IGO/Items")]
	static void Init()
	{
		EditorWindow window = GetWindow(typeof(ItemWindows),false,"ItemManager"); 
		window.Show();
	}

	void OnGUI (){
		if(GeneralValue.igoData.AllItems == null){
			CreateNewItemGUI();
		}else{
			ThereIsItemGUI();
		}
		if (GUI.changed) 
		{
			EditorUtility.SetDirty(GeneralValue.igoData);
		}
	}

	void ThereIsItemGUI (){
		allItemName = new string [GeneralValue.igoData.AllItems.Length + 1];
		for (int i = 0; i < GeneralValue.igoData.AllItems.Length; i++)
		{
			allItemName[i] = GeneralValue.igoData.AllItems[i].name;
		}
		allItemName[allItemName.Length-1] = "New Item";
		itemIndex = EditorGUILayout.Popup(itemIndex, allItemName);

		if(itemIndex == allItemName.Length-1){
			CreateNewItemGUI();
		}else{
			CommonGUI();
		}
	}

    void CommonGUI(){
		currentItem = GeneralValue.igoData.AllItems[itemIndex];
        InformationsGUI();

		if(GUI.changed){
			EditorUtility.SetDirty(this);
		}
	}


	string _tempName;
	void CreateNewItemGUI(){
		_tempName = EditorGUILayout.TextField("Name : ",_tempName);

		if(GUILayout.Button("Create New Item")){
			if(GeneralValue.igoData.AllItems!=null){
				var _item = GeneralValue.igoData.AllItems;
				GeneralValue.igoData.AllItems = new Item [GeneralValue.igoData.AllItems.Length+1];
				for (int i = 0; i < _item.Length; i++)
				{	
					GeneralValue.igoData.AllItems[i] = _item[i];
				}
				GeneralValue.igoData.AllItems[GeneralValue.igoData.AllItems.Length-1] = new Item(_tempName);
			}else{
				GeneralValue.igoData.AllItems = new Item[] {new Item(_tempName)};
			}
		}
	}

	Vector2 scroll;
	Vector2 scroll2;
	//Description GUI
	void InformationsGUI(){
		GUILayout.Label("Information",EditorStyles.boldLabel);
		currentItem.name = EditorGUILayout.TextField("Name : ",currentItem.name);
		
		currentItem.inventoryIcon = EditorGUILayout.ObjectField("Inventory Icon :",currentItem.inventoryIcon, typeof(Sprite), true) as Sprite;
		currentItem.inventoryImage = EditorGUILayout.ObjectField("Inventory Image :",currentItem.inventoryImage, typeof(Sprite), true) as Sprite;
		currentItem.objectSprite = EditorGUILayout.ObjectField("Object Sprite :",currentItem.objectSprite, typeof(Sprite), true) as Sprite;
		
		GUILayout.Label("Description :");
		scroll = EditorGUILayout.BeginScrollView(scroll);
			currentItem.description = EditorGUILayout.TextArea(currentItem.description,GUILayout.Height(100));
        EditorGUILayout.EndScrollView();

		GUILayout.Label("Explanation :");
		scroll2 = EditorGUILayout.BeginScrollView(scroll2);
			currentItem.explaination = EditorGUILayout.TextArea(currentItem.explaination,GUILayout.Height(100));
        EditorGUILayout.EndScrollView();
	}
}

