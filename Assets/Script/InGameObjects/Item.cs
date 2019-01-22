using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.IGO {

	[System.Serializable]
	public class Item : InGameObjectBase {
		
		[Header("Item Parameters")]
		public Sprite objectSprite;
		public Sprite inventoryIcon;
		public Sprite inventoryImage;


		
		[TextArea]
		public string explaination;

		public Item (string _name){
			name = _name;
		}
	}
}
