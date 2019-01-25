using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.IGO {
	[System.Serializable]
	public class Character : InGameObjectBase {

		[Header("Character's Parameters")]
		public Animator animator;

		[HideInInspector]
		public Sprite inventoryIcon;
		public Sprite inventoryImage;

		public Sprite[][] animListe;


		//Emotions lists
		[HideInInspector]
		public Sprite[] neutralSprites;
		[HideInInspector]
		public Sprite[] angrySprites;
		[HideInInspector]
		public Sprite[] proudSprites;
		[HideInInspector]
		public Sprite[] mockingSprites;
		[HideInInspector]
		public Sprite[] gaySprites;
		[HideInInspector]
		public Sprite[] surprisedSprites;
		[HideInInspector]
		public Sprite[] happySprites;
		[HideInInspector]
		public Sprite[] thinkingSprites;

		public Character (string _name){
			name = _name;
			isDiscovered = false;
			animListe = new Sprite[8][];
			for (int i = 0; i < animListe.Length; i++)
			{
				animListe[i] = new Sprite [2];
			}

			neutralSprites = new Sprite[2];
			angrySprites = new Sprite[2];
			proudSprites = new Sprite[2];
			mockingSprites = new Sprite[2];
			gaySprites = new Sprite[2];
			surprisedSprites = new Sprite[2];
			happySprites = new Sprite[2];
			thinkingSprites = new Sprite[2];
		}

	}


}