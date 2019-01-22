using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VolarelaNS
{
    using IGO;
    using UnityEngine.UI;

    namespace Menu
    {
        public class CharaMenuButton : MonoBehaviour, IMenuButton
        {
            private Character charTarget;            
            public InGameObjectBase target
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

            private Image thisImg;
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
                MenuManager.instance.ChangeDescription(charTarget.description,"");
            }

            public void OnCreated()
            {
                thisImg.sprite = charTarget.inventoryIcon;
            }
        }
    }

}
