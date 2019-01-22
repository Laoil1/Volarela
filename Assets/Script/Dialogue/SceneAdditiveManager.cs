using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.DialogueNS
{		
	public class SceneAdditiveManager : MonoBehaviour {
		public static SceneAdditiveManager instance;

		public bool isOnDialogue;

		public GameObject dialogueObject;
		public GameObject menuObject;

		void Awake ()
		{
			if(instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(this);
			}

		}

		public void SetDialogueActive()	
		{
			dialogueObject.SetActive(true);
		}

		public void DisableDialogue()
		{
			dialogueObject.SetActive(false);
		}

		public void SetMenuActive()	
		{
			menuObject.SetActive(true);
		}
		
		public void DisableMenu()
		{
			menuObject.SetActive(false);
		}

		public void ToogleMenu()
		{
			menuObject.SetActive(menuObject.activeInHierarchy);
		}

	}
}
