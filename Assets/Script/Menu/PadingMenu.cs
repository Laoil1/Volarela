using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace VolarelaNS
{
	using IGO;
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
			public float ecartViewPort = 40.0f;
			public RectTransform self;
			public GameObject menuButton;
			public PadingType padingType = PadingType.Item;
			public ActiveChild thisActiveChild;
			


			public void SetPadingMenu()
			{
				DestroyImediateChild();
				SetChild();
			}

			private void SetChild()
			{
				thisActiveChild.childsIMB = new List<MenuButtonParent>();
				switch (padingType)
				{
					case PadingType.Item:
						for (var i = 0; i < GeneralValue.igoData.AllItems.Length; i++)
						{
							CreateChild<ItemMenuButton>(GeneralValue.igoData.AllItems[i], i);
						}
						SetSize();
						break;
						
					case PadingType.Perso:
							for (var i = 0; i < GeneralValue.igoData.AllCharacters.Length; i++)
						{
							CreateChild<CharaMenuButton>(GeneralValue.igoData.AllCharacters[i], i);
						}
						SetSize();
						break;
						
					case PadingType.Objectives:
						for (var i = 0; i < GeneralValue.igoData.AllGoals.Length; i++)
						{
							CreateChild<ObjectiveMenuButton>(GeneralValue.igoData.AllGoals[i], i);
						}
						SetSizeObj();
						break;
				}
				EditorUtility.SetDirty(thisActiveChild);
			}

			private void DestroyImediateChild()
			{
				while(self.childCount != 0)
				{
					GameObject.DestroyImmediate(self.GetChild(0).gameObject);
				}
				
			}
			private void CreateChild<T> (InGameObjectBase igo, int i) where T : MenuButtonParent
			{
				T elem = Instantiate(menuButton,self).GetComponent<T>() ;
				elem.igo = igo;
				elem.OnCreated();
				elem.index = i;
				thisActiveChild.childsIMB.Add((T)elem);

			}

			private void SetSize()
			{
				var gridLay = (GridLayoutGroup)layoutGroup;
				self.sizeDelta = new Vector2(0,self.childCount/gridLay.constraintCount*gridLay.cellSize.x+ecartViewPort);
			}

			private void SetSizeObj()
			{
				var verLay = GetComponent<VerticalLayoutGroup>();
				self.sizeDelta = new Vector2(0,self.childCount*(menuButton.GetComponent<RectTransform>().sizeDelta.y)+ecartViewPort);
			}

		}
	}

}