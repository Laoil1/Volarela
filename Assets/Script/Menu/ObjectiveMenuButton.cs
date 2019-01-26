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
		public class ObjectiveMenuButton : MenuButtonParent, IMenuButton
		{

            [HideInInspector]
            public Goal goalTarget;
            public override InGameObjectBase igo
            {
                get
                {
                    return goalTarget;
                }

                set
                {
                    goalTarget = (Goal)value;
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

            public override void  OnClickSetMenu()
            {
                MenuManager.instance.SetButtonActive(MenuManager.instance.information, true);
                MenuManager.instance.ChangeDescription(igo.description,"");
            }

            public override void OnCreated()
            {
                EditorUtility.SetDirty(this);
                thisText.text = goalTarget.name;
                ThisGo = gameObject;
            }
		}	
	}
}
