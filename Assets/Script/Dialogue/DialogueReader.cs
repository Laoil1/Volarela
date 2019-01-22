using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VolarelaNS.DialogueNS{
	public class DialogueReader : MonoBehaviour {
		
		public static DialogueReader Instance;

		public Dialogue dialogue;
		[HideInInspector]
		public Node actualNode;

		public Button[] buttonsSentence;
		public Button[] buttonsAnswer;
		public GameObject nextButton;
		public GameObject otherNextButton;
		public GameObject quitButton;
		private int textIndex;
		private List<string> listText;
		public int maxCharactersToDisplay = 405;
		public Text text;
		public InputField inputField; 
		public GameObject validateBut;
		public CharactersDynamicAnimation cda; 
		public QuitDialogue quitDialogue;
		public AudioSource audioSource;
		// Use this for initialization

		void Awake ()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if (Instance != this)
			{
				Destroy(this);
			}
		}

		void Start () {
			GetStartNode();
		}
		
		// Update is called once per frame
		void Update () 
		{	
		}

		private void ReadNode ()
		{
			ResetButton();
			
			switch (actualNode.ton)
			{
				case TypeOfNode.ConditionCheck:
					InteractConditionCheck();
					break;
				case TypeOfNode.ConditionChange:
					InteractConditionChange();
					break;
				case TypeOfNode.End:
					InteractEnd();
					break;
				default :
					LargeText();
					break;

			}
		}

		private void ResetButton()
		{
			for (int i = 0; i < 4; i++)
			{
				var img = buttonsSentence[i].transform.GetChild(1).GetComponent<Image>();
				img.sprite = null;
				img.color = new Color(0,0,0,0);

				img = buttonsAnswer[i].transform.GetChild(1).GetComponent<Image>();
				img.sprite = null;
				img.color = new Color(0,0,0,0);

				buttonsAnswer[i].gameObject.SetActive(false);
				buttonsSentence[i].gameObject.SetActive(false);
			}
			quitButton.SetActive(false);
			nextButton.SetActive(false);
			inputField.gameObject.SetActive(false);
			validateBut.SetActive(false);
			otherNextButton.SetActive(false);
		}

		private void InteractSentenceQuestion ()
		{
			foreach(var but in buttonsSentence)
			{
				but.gameObject.SetActive(false);
			}
			for (int i = 0; i <= actualNode.questionsLenght; i++)
			{	
				buttonsSentence[i].gameObject.SetActive(true);
				buttonsSentence[i].GetComponentInChildren<Text>().text = actualNode.questions[i];
				if(actualNode.pictures[i] == null) { continue;}
				var img = buttonsSentence[i].transform.GetChild(1).GetComponent<Image>();
				img.sprite = actualNode.pictures[i];
				img.color = Color.white;
			}
		}

		private void InteractSentenceAnswer ()
		{
			quitButton.SetActive(true);
			foreach(var but in buttonsSentence)
			{
				but.gameObject.SetActive(false);
			}
			for (int i = 0; i <= actualNode.answersLengh; i++)
			{	
				buttonsAnswer[i].gameObject.SetActive(true);
				buttonsAnswer[i].GetComponentInChildren<Text>().text = actualNode.answer[i];
				if(actualNode.pictures[i] == null) {continue;}
				var img = buttonsAnswer[i].transform.GetChild(1).GetComponent<Image>();
				img.sprite = actualNode.pictures[i];
				img.color = Color.white;
			}
		}

		private void InteractConditionCheck ()
		{
			if(actualNode.condition.state == true)
			{
				ChangeNode(0);
			}
			else
			{
				ChangeNode(1);
			}
		}

		private void InteractConditionChange ()
		{
			actualNode.condition.state = actualNode.changingConidition;
			ChangeNode(0);
		}

		private void InteractCinematique()
		{
			nextButton.gameObject.SetActive(false);
			otherNextButton.SetActive(true);

		}

		private void InteractEntry ()
		{
			inputField.gameObject.SetActive(true);
			validateBut.SetActive(true);
		}

		private void InteractEnd()
		{
			quitDialogue.QuitDialogueButton();
		}

		private void LargeText()
		{
			listText = TextManager.ConvertLargeText(actualNode.fullText, maxCharactersToDisplay);
			textIndex = 0;
			cda.emo = actualNode.emotion;
			cda.SetAnim(actualNode.characterTalking);
			NextTextEntry();
		}

		public void NextButtonPressed()
		{
			textIndex ++;
			NextTextEntry();
		}

		private void NextTextEntry ()
		{
			
			text.text = listText[textIndex];
			audioSource.clip = actualNode.textAudio[textIndex];
			audioSource.Play();

			if(textIndex == listText.Count-1)
			{
				nextButton.gameObject.SetActive(false);

				switch (actualNode.ton)
				{
					case TypeOfNode.SentenceQuestion:
						InteractSentenceQuestion();
						break;
					case TypeOfNode.SentenceAnswer:
						InteractSentenceAnswer();
						break;	
					case TypeOfNode.TextEntry:
						InteractEntry();
						break;
					case TypeOfNode.Cinematique :
						InteractCinematique();
						break;
					default :
						Debug.LogError("This isn't a node with text");
						break;
				}
			}
			else
			{
				if(nextButton.gameObject.activeInHierarchy) 
				{
					return;
				}
				
				nextButton.gameObject.SetActive(true);
			}
		}

		public void ChangeNode (int index){
			if(dialogue.FindNodeByID(actualNode.outPoint[index].connectedInNode)!=null)
			{
				actualNode = dialogue.FindNodeByID (actualNode.outPoint[index].connectedInNode);
			}
			else
			{
				Debug.LogError("There is no Node connected, if you want to end the dialogue please create an End Node");
			}
			ReadNode();
		}
		public void ChangeNode ()
		{
			if(dialogue.FindNodeByID(actualNode.outPoint[0].connectedInNode)!=null)
			{
				actualNode = dialogue.FindNodeByID (actualNode.outPoint[0].connectedInNode);
			}
			else
			{
				Debug.LogError("There is no Node connected, if you want to end the dialogue please create an End Node");
			}
			ReadNode();
		}

		public void Validate ()
		{
			if(inputField.text.EqualTextWithoutCase(actualNode.textEntry))
			{
				ChangeNode(0);
			}
			else
			{
				ChangeNode(1);
				/* 
				if(actualNode.approTextEntry[0] == "")
				{
					foreach (var item in actualNode.approTextEntry)
					{
						if(item != "")
						{
							if(item.EqualTextWithoutCase(actualNode.textEntry))
							{
								ChangeNode(0);
							}
						}
					}
				}
				*/
			}
		}
		void GetStartNode (){
			actualNode = dialogue.FindNodeByID (dialogue.FindNodeByID(0).outPoint[0].connectedInNode);
			ReadNode();
		}
	}
}
