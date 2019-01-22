using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VolarelaNS
{
	namespace Menu
	{
		public enum  PadingType
		{
			Item,
			Perso,
			Objectives

		}
		public class PadingMenu : MonoBehaviour 
		{
			public LayoutGroup layoutGroup;
			public RectTransform self;
			public GameObject menuButton;
			public PadingType padingType = PadingType.Item;

		}
	}

}