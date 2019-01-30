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
        [System.Serializable]
		public class ItemMenuButton : MenuButtonParent, IMenuButton
		{
  			[HideInInspector]
            public Item itemTarget;
            public override InGameObjectBase igo
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
            public override Image ThisImg 
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
            public override Text ThisText 
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

            private GameObject thisGo;
            public override GameObject ThisGo
            {
                get
                {
                    return thisGo;
                }

                set
                {
                    thisGo = value;
                }
            }
            public override void OnClickSetMenu()
            {
                Debug.Log("ItemMenu clicked");
                MenuManager.instance.SetButtonActive(MenuManager.instance.information, true);
                MenuManager.instance.SetButtonActive(MenuManager.instance.cadre, true);
                MenuManager.instance.ChangeDescription(igo.description,itemTarget.explaination);
                MenuManager.instance.ChangeImage(itemTarget.inventoryImage );
            }

            public override void OnCreated()
            {
                // EditorUtility.SetDirty(this);
                thisImg.sprite = itemTarget.inventoryIcon;
                ThisGo = gameObject;
            }
		}	
	}
}
