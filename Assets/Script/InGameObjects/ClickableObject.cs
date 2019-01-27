using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolarelaNS;


namespace VolarelaNS.IGO{

	public enum IGOChoices {
		Character,
		Item,
		Goal
	}
	public class ClickableObject : MonoBehaviour {
		[HideInInspector]
		public IGOChoices choice;

		[HideInInspector]
		public InGameObjectBase displayedObject;

		[HideInInspector]
		public int doIndex;

		public void SetSprite()
		{
			if(displayedObject == null) return;
			GetComponent<SpriteRenderer>().sprite = displayedObject.objectSprite;
		}
	}

}