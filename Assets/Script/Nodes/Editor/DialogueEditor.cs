using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS.DialogueNS;
using VolarelaNS;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor {

	Node node;
	Dialogue dialogue;

	bool debug;
	int lenght;

	public void OnEnable (){
		dialogue = target as Dialogue; 
	}

	public override void OnInspectorGUI(){
		if (debug) 
			DebugGUI();
		else {
			node = dialogue.selectedNode; 
			if(dialogue.areANodeSelected){
				switch (node.ton){
					case TypeOfNode.Start :
						StartGui();
						break;
					case TypeOfNode.SentenceQuestion :
						SentenceQuestionGUI();
						break;
					case TypeOfNode.SentenceAnswer :
						SentenceAnswerGUI();
						break;
					case TypeOfNode.ConditionCheck : 
						ConditionGUI();
						break;
					case TypeOfNode.ConditionChange : 
						ConditionChangeGUI();
						break;
					case TypeOfNode.TextEntry : 
						TextEntryGUI();
						break;
					case TypeOfNode.Cinematique :
						CineGUI();
						break;
					case TypeOfNode.End :
						EndGui();
						break;
				}
			}
		debug = EditorGUILayout.Toggle("DebugMode",debug);
		}
		if (GUI.changed){
			EditorUtility.SetDirty(target);
		}
	}

	void SentenceQuestionGUI(){
		DefaultTextGUI();
		if(node.questions == null || node.questions.Count == 0){
			node.questions = new List<string>(){"Je dois y aller","","",""};
		}
		node.questionsLenght = ListAndArrayDisplayAndImage(0,3, node.questionsLenght,node.questions,"Réponses","Answers");
	}

	void SentenceAnswerGUI(){
		DefaultTextGUI();
		if(node.answer == null || node.answer.Count == 0){
			node.answer = new List<string>(){"Reponse A","Reponse B","Reponse C","Reponse D"};
		}
		node.answersLengh = ListAndArrayDisplayAndImage(0,3,node.answersLengh,node.answer,"Réponses","Answers");

	}

	void ConditionGUI()
	{
		EditorGUILayout.LabelField("Condition", EditorStyles.boldLabel);
	}
	void ConditionChangeGUI()
	{
		EditorGUILayout.LabelField("Condition Change", EditorStyles.boldLabel);
		node.changingConidition = EditorGUILayout.Toggle("Changing Condition",node.changingConidition);
	}

	private void DefaultTextGUI()
	{
		node.name = EditorGUILayout.TextField("Label",node.name);
		node.fullText = EditorGUILayout.TextArea(node.fullText);
		allCharacterName = new string [GeneralValue.igoData.AllCharacters.Length];
		for (int i = 0; i < GeneralValue.igoData.AllCharacters.Length; i++)
		{
			allCharacterName[i] = GeneralValue.igoData.AllCharacters[i].name;
		}
		characterIndex = EditorGUILayout.Popup(characterIndex, allCharacterName);
		node.characterTalking = GeneralValue.igoData.AllCharacters[characterIndex];
		node.emotion = (Emotions)EditorGUILayout.EnumPopup(node.emotion);
		SetUpFullTextWithAudio(node.fullText.ConvertLargeText(405));
	}
	string[] allCharacterName;
	int characterIndex;
	void CineGUI()
	{
		DefaultTextGUI();
	}

	void TextEntryGUI()
	{
		EditorGUILayout.LabelField("Text Entry");
		node.fullText = EditorGUILayout.TextArea(node.fullText);
		/* 
		if(node.approTextEntry == null || node.approTextEntry.Count == 0)
		{
			node.approTextEntry = new List<string>(){""};
		}
		node.approTextEntryLengh = ListAndArrayDisplay(0,30,node.approTextEntryLengh,node.approTextEntry,"Textes Accéptés","Entrée");
		*/
		

	}
	void StartGui(){
		EditorGUILayout.LabelField("Start");
	}

	void EndGui(){
		EditorGUILayout.LabelField("End");		
	}

	int ListAndArrayDisplayAndImage(int lenghtMin, int lenghtMax, int lenght, List<string> list, string catName, string elementName){
		lenght = EditorGUILayout.IntSlider(catName,lenght,lenghtMin,lenghtMax);
		for (int i = 0; i <= lenght; i++)
		{
			
			list[i] = EditorGUILayout.TextField (elementName + " " + (i).ToString(),list[i]);
			node.pictures[i] = EditorGUILayout.ObjectField(node.pictures[i], typeof(Sprite),false) as Sprite;
		}
		return lenght;

	}

	private void SetUpFullTextWithAudio (List<string> textList)
	{
		if(node.textAudio == null) {node.textAudio = new List<AudioClip>();};
		if(textList.Count>node.textAudio.Count)
		{
			for (int i = node.textAudio.Count; i <textList.Count; i++)
			{
				node.textAudio.Add(null);
			}
		}
		if(textList.Count<node.textAudio.Count)
		{
			while (node.textAudio.Count != textList.Count)			
			{
				node.textAudio.RemoveAt(node.textAudio.Count-1);
			}

		}
		

		for (int i = 0; i < textList.Count; i++)
		{
			EditorGUILayout.LabelField("De "+ textList[i].GetFirstWord() + " à " + textList[i].GetLastWord());
			node.textAudio[i]= EditorGUILayout.ObjectField(node.textAudio[i], typeof(AudioClip),false) as AudioClip;
		}

	}

	void DebugGUI(){
		DrawDefaultInspector();
		debug = EditorGUILayout.Toggle("DebugMode",debug);

	}

}
