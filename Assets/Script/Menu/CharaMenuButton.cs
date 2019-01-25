﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VolarelaNS
{
    using IGO;
    using UnityEngine.UI;

    namespace Menu
    {
        public class CharaMenuButton : MonoBehaviour, IMenuButton
        {
            [HideInInspector]
            public Character charTarget;            
            public InGameObjectBase igo
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
                MenuManager.instance.SetButtonActive(MenuManager.instance.information, true);
                MenuManager.instance.SetButtonActive(MenuManager.instance.cadre, true);
                MenuManager.instance.ChangeDescription(igo.description,"");
                MenuManager.instance.ChangeImage(charTarget.inventoryImage );
            }

            public void OnCreated()
            {
                EditorUtility.SetDirty(this);
                thisImg.sprite = charTarget.inventoryIcon;
            }
        }
    }

}
