using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VolarelaNS.Menu
{

	public class ChangeSpriteIfTrue : MonoBehaviour {

		public Image image;
		public Sprite validateSprite;
		public Sprite unvalidateSprite;
		public ObjectiveMenuButton objectiveMenu;
		
		void OnEnable()
		{
			if(GeneralValue.igoData.AllGoals[objectiveMenu.index].isValidate)
			{
				image.sprite = validateSprite;
			}
			else
			{
				image.sprite = unvalidateSprite;
			}
		}
	}

}