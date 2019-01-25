using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

			public void SetPadingMenu()
			{
				DestroyImediateChild();
				SetChild();
			}

			private void SetChild()
			{
				switch (padingType)
				{
					case PadingType.Item:
						foreach (var item in GeneralValue.igoData.AllItems)
						{
							CreateChild<ItemMenuButton>(item);
						}
						SetSize();
						break;
						
					case PadingType.Perso:
						foreach (var chara in GeneralValue.igoData.AllCharacters)
						{
							CreateChild<CharaMenuButton>(chara);
						}
						SetSize();
						break;
						
					case PadingType.Objectives:
						
						foreach (var goal in GeneralValue.igoData.AllGoals)
						{
							CreateChild<ObjectiveMenuButton>(goal);
						}
						SetSizeObj();
						break;
				}
			}

			private void DestroyImediateChild()
			{
				while(self.childCount != 0)
				{
					GameObject.DestroyImmediate(self.GetChild(0).gameObject);
				}
				
			}
			private void CreateChild<T> (InGameObjectBase igo) where T : IMenuButton
			{
				T elem = Instantiate(menuButton,self).GetComponent<T>() ;
				elem.igo = igo;
				elem.OnCreated();
			}

			private void SetSize()
			{
				var gridLay = (GridLayoutGroup)layoutGroup;
				self.sizeDelta = new Vector2(0,self.childCount/gridLay.constraintCount*gridLay.cellSize.x+ecartViewPort);
				Debug.Log(self.childCount);
				Debug.Log(self.childCount/gridLay.constraintCount*gridLay.cellSize.x+ecartViewPort);
			}

			private void SetSizeObj()
			{
				var verLay = GetComponent<VerticalLayoutGroup>();
				self.sizeDelta = new Vector2(0,self.childCount*(menuButton.GetComponent<RectTransform>().sizeDelta.y)+ecartViewPort);
			}

		}
	}

}