using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VolarelaNS.DialogueNS
{

	public class LoadDialogueAndMenu : MonoBehaviour 
	{

		public string sceneUIobj;

		public void Start()
		{
			Debug.Log(SceneManager.sceneCount);
			InitializeUIScene();
		}
		
		private void InitializeUIScene()
		{
			if(SceneManager.sceneCount != 2)
			{
				SceneManager.LoadScene(sceneUIobj, LoadSceneMode.Additive);
				return;
			}
			if(SceneManager.GetSceneAt(1).name != sceneUIobj)
			{
				SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).name);
				SceneManager.LoadScene(sceneUIobj, LoadSceneMode.Additive);
			}
		}

		public void LoadDialogueFonc(Dialogue dialogue)
		{
			SceneAdditiveManager.instance.SetDialogueActive();
			DialogueReader.Instance.dialogue = dialogue;
		}

		public void LoadMenu()
		{
			SceneAdditiveManager.instance.SetMenuActive();
		}

		public void DesactivateMenuAndDialogue()
		{
			SceneAdditiveManager.instance.DisableDialogue();
			SceneAdditiveManager.instance.DisableMenu();
		}

	}
}
