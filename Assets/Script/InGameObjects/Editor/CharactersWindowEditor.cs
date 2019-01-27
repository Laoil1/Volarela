using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.IGO;


public class CharacterWindows : EditorWindow {

	string[] allCharacterName;
	Character currentCharacter;

	int characterIndex = 0;

	public enum Parameters {
		Descriptions,
		Animations
	}
	public Parameters para;



	//Initialisation
	[MenuItem("Volarela/IGO/Characters")]
	static void Init()
	{
		EditorWindow window = GetWindow(typeof(CharacterWindows),false,"CharaManager"); 
		window.Show();
	}

	void OnGUI ()
	{
		if (GeneralValue.igoData.AllCharacters == null) {
			CreateNewCharacterGUI ();
		} else {
			ThereIsCharacterGUI ();
		}
		if (GUI.changed) 
		{
			EditorUtility.SetDirty(GeneralValue.igoData);
			foreach (var item in GameObject.FindObjectsOfType<ClickableObject>())
			{
				item.SetSprite();
			}
		}
	}
	
	string _tempName;
	void CreateNewCharacterGUI(){
		_tempName = EditorGUILayout.TextField("Name : ",_tempName);

		if(GUILayout.Button("Create New Character")){
			if(GeneralValue.igoData.AllCharacters!=null){
				var _char = GeneralValue.igoData.AllCharacters;
				GeneralValue.igoData.AllCharacters = new Character [GeneralValue.igoData.AllCharacters.Length+1];
				for (int i = 0; i < _char.Length; i++)
				{	
					GeneralValue.igoData.AllCharacters[i] = _char[i];
				}
				GeneralValue.igoData.AllCharacters[GeneralValue.igoData.AllCharacters.Length-1] = new Character(_tempName);
			}else{
				GeneralValue.igoData.AllCharacters = new Character[] {new Character(_tempName)};
			}
		}
	}


	void ThereIsCharacterGUI (){
		allCharacterName = new string [GeneralValue.igoData.AllCharacters.Length + 1];
		for (int i = 0; i < GeneralValue.igoData.AllCharacters.Length; i++)
		{
			allCharacterName[i] = GeneralValue.igoData.AllCharacters[i].name;
		}
		allCharacterName[allCharacterName.Length-1] = "New Character";
		characterIndex = EditorGUILayout.Popup(characterIndex, allCharacterName);

		if(characterIndex == allCharacterName.Length-1){
			CreateNewCharacterGUI();
		}else{
			CommonGUI();
		}
	}

	void CommonGUI(){
		currentCharacter = GeneralValue.igoData.AllCharacters[characterIndex];

		if(GUILayout.Button("Delete"))
		{
			GeneralValue.igoData.AllCharacters = GeneralValue.igoData.AllCharacters.RemoveElement(characterIndex);
			return;
		}
		
		GUILayout.Label("Parmaters",EditorStyles.boldLabel);
		para = (Parameters)EditorGUILayout.EnumPopup(para, GUILayout.Width(300));

		switch (para)
		{
			case Parameters.Descriptions :
				InformationsGUI();
				break;
			
			case Parameters.Animations :
				AnimationGUI();
				break;


			default: 
				Debug.LogError("Unrecognized Option");
				break;

		}
		if(GUI.changed){
			EditorUtility.SetDirty(this);
		}
	}

	Vector2 scroll;
	//Description GUI
	void InformationsGUI(){
		GUILayout.Label("Information",EditorStyles.boldLabel);
		currentCharacter.name = EditorGUILayout.TextField("Name : ",currentCharacter.name);

		currentCharacter.inventoryIcon = EditorGUILayout.ObjectField("Inventory Icon :",currentCharacter.inventoryIcon, typeof(Sprite), true) as Sprite;
		currentCharacter.inventoryImage = EditorGUILayout.ObjectField("Inventory Image :",currentCharacter.inventoryImage, typeof(Sprite), true) as Sprite;
		currentCharacter.objectSprite = EditorGUILayout.ObjectField("Object Sprite :",currentCharacter.objectSprite, typeof(Sprite), true) as Sprite;
		
		GUILayout.Label("Description :");
		scroll = EditorGUILayout.BeginScrollView(scroll);
			currentCharacter.description = EditorGUILayout.TextArea(currentCharacter.description,GUILayout.Height(200));
        EditorGUILayout.EndScrollView();
	}



	//Animation GUI Stuff
	Emotions emotion;
	Sprite[] currentAnimation;

	void AnimationGUI(){
		GUILayout.Label("Animation",EditorStyles.boldLabel);
		emotion = (Emotions)EditorGUILayout.EnumPopup("Emotions",emotion, GUILayout.Width(300));
		//GUILayout.BeginArea(new Rect(0,0,100,100));
		GUILayout.Label(emotion.ToString()+":");

		currentAnimation = SetAnimation(emotion);
	
		currentAnimation [0] = EditorGUILayout.ObjectField("Frame 1 :",currentAnimation [0], typeof(Sprite), true) as Sprite;
		currentAnimation [1] = EditorGUILayout.ObjectField("Frame 2 :",currentAnimation [1], typeof(Sprite), true) as Sprite;

	}
	
	Sprite[] SetAnimation (Emotions _emo){
		Sprite[] _spriteArray = null;
		switch (_emo)
		{
			case Emotions.Neutral :
				currentCharacter.neutralSprites = SpriteInitialiseur(currentCharacter.neutralSprites);
				_spriteArray = currentCharacter.neutralSprites;
				break;
			case Emotions.Angry :				
				currentCharacter.angrySprites = SpriteInitialiseur(currentCharacter.angrySprites);
				_spriteArray = currentCharacter.angrySprites;
				break;
			case Emotions.Proud :
				currentCharacter.proudSprites = SpriteInitialiseur(currentCharacter.proudSprites);
				_spriteArray = currentCharacter.proudSprites;
				break;
			case Emotions.Mocking :
				currentCharacter.mockingSprites = SpriteInitialiseur(currentCharacter.mockingSprites);
				_spriteArray = currentCharacter.mockingSprites;
				break;
			case Emotions.Gay :
				currentCharacter.gaySprites = SpriteInitialiseur(currentCharacter.gaySprites);
				_spriteArray = currentCharacter.gaySprites;
				break;
			case Emotions.Surprised :
				currentCharacter.surprisedSprites = SpriteInitialiseur(currentCharacter.surprisedSprites);
				_spriteArray = currentCharacter.surprisedSprites;
				break;			
			case Emotions.Happy :
				currentCharacter.happySprites = SpriteInitialiseur(currentCharacter.happySprites);
				_spriteArray = currentCharacter.happySprites;
				break;
			case Emotions.Thinking :
				currentCharacter.thinkingSprites = SpriteInitialiseur(currentCharacter.thinkingSprites);
				_spriteArray = currentCharacter.thinkingSprites;
				break;
			default:
				Debug.LogError("No Emmotion allowed");
				break;
		}
		
		return _spriteArray;

	}
	Sprite[] SpriteInitialiseur (Sprite[] _sprite){
		if(_sprite.Length == 0){
			_sprite = new Sprite[2];
		}
		return _sprite;
	}
}

