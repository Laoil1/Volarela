using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.Menu
{
	using IGO;
	public class ActiveChild : MonoBehaviour {
		public List<MenuButtonParent> childsIMB;
		void OnEnable()
		{
			int index = -1; 
			if(childsIMB[0].GetType() == typeof(CharaMenuButton)){ index = 0;}
			if(childsIMB[0].GetType() == typeof(ItemMenuButton)) { index = 1;}
			if(childsIMB[0].GetType() == typeof(ObjectiveMenuButton)) { index = 2;}

			InGameObjectBase[] igoGeneralList = new InGameObjectBase[0];

			switch (index)
			{
				case 0:
					igoGeneralList=igoGeneralList.CopyToArray(GeneralValue.igoData.AllCharacters);
					break;
				
				case 1:
					igoGeneralList=igoGeneralList.CopyToArray(GeneralValue.igoData.AllItems);
					break;
				
				case 2:
					igoGeneralList=igoGeneralList.CopyToArray(GeneralValue.igoData.AllGoals);
					break;
			}

			for(var i = 0; i<childsIMB.Count; i++)
			{
				if(!igoGeneralList[i].isDiscovered)
				{
					childsIMB[i].gameObject.SetActive(false);	
				}
				else
				{
					childsIMB[i].gameObject.SetActive(true);
				} 
			}

		}
	}

}