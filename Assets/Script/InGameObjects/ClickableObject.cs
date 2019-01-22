using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.IGO{

	public class ClickableObject : MonoBehaviour {
		public enum Choices {
			Character,
			Item
		}
		[HideInInspector]
		public Choices choice;


		[HideInInspector]
		public InGameObjectBase displayedObject;

		[HideInInspector]
		public int doIndex;
	}

}