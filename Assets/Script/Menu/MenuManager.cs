using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace VolarelaNS
{
	namespace Menu
	{
		public class MenuManager : MonoBehaviour 
		{

			public static MenuManager instance;
			public TextMananger tm;
			public Image image;
			public GameObject information;
			public GameObject cadre;

			public GameObject[] closingList;

			public void Awake()
			{
				if(instance == null)
				{
					instance = this;
				}
				else
				{
					Destroy(this);
				}
			}
			
			public void ChangeDescription(string firstString, string secondString)
			{
				tm.entry[0] = firstString;
				tm.entry[1] = secondString;
			}

			public void ChangeImage(Sprite spr)
			{
				image.sprite = spr;
			}

			public void ToogleButton (GameObject button)
			{
				button.SetActive(!button.activeInHierarchy);
			}
			public void SetButtonActive (GameObject button, bool state)
			{
				button.SetActive(state);
			}
			public void SetButtonTrue (GameObject button)
			{
				button.SetActive(true);
			}
			public void SetButtonFalse (GameObject button)
			{
				button.SetActive(false);
			}

			public void CloseAll()
			{
				foreach (var item in closingList)
				{
					item.SetActive(false);
				}
			}
		}
	}

}

