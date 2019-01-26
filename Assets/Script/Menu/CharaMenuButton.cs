using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VolarelaNS
{
    using IGO;
    using UnityEngine.UI;

    namespace Menu
    {
        public class CharaMenuButton : MenuButtonParent
        {
            
            
            [HideInInspector]
            public Character charTarget;            
            public override InGameObjectBase igo
            {
                get
                {
                    return charTarget;
                }

                set
                {
                    charTarget = (Character)value;
                }
            }

            public  Image thisImg;
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
            private GameObject thisGO;

            public override GameObject ThisGo
            {
                get
                {
                    return thisGO;
                }

                set
                {
                    thisGO = value;
                }
            }

            public override void OnClickSetMenu()
            {
                MenuManager.instance.SetButtonActive(MenuManager.instance.information, true);
                MenuManager.instance.SetButtonActive(MenuManager.instance.cadre, true);
                MenuManager.instance.ChangeDescription(igo.description,"");
                MenuManager.instance.ChangeImage(charTarget.inventoryImage );
            }

            public override void OnCreated()
            {
                EditorUtility.SetDirty(this);
                thisImg.sprite = charTarget.inventoryIcon;
                ThisGo = gameObject;
            }
        }
    }

}
