using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace VolarelaNS
{
	using IGO;
	namespace Menu
	{
		public class ItemMenuButton : MonoBehaviour, IMenuButton
		{
  			[HideInInspector]
            public Item itemTarget;
            public InGameObjectBase igo
            {
                get
                {
                    return itemTarget;
                }

                set
                {
                    itemTarget = (Item)value;
                }
            }

            public Image thisImg;
            public Image ThisImg 
            {
                get
                {
                    return thisImg;
                }

                set
                {
                    thisImg = value;
                }
            }

            public Text thisText;
            public Text ThisText 
            {
                get
                {
                    return thisText;
                }

                set
                {
                    thisText = value;
                }
            }


            public void OnClickSetMenu()
            {
                Debug.Log("ItemMenu clicked");
                MenuManager.instance.SetButtonActive(MenuManager.instance.information, true);
                MenuManager.instance.SetButtonActive(MenuManager.instance.cadre, true);
                MenuManager.instance.ChangeDescription(igo.description,itemTarget.explaination);
                MenuManager.instance.ChangeImage(itemTarget.inventoryImage );
            }

            public void OnCreated()
            {
                EditorUtility.SetDirty(this);
                thisImg.sprite = itemTarget.inventoryIcon;
            }
		}	
	}
}
