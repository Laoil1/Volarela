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

		}
	}

}

