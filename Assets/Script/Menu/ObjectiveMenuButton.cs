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
		public class ObjectiveMenuButton : MonoBehaviour, IMenuButton
		{
  			[HideInInspector]
            public Goal goalTarget;
            public InGameObjectBase igo
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
                MenuManager.instance.ChangeDescription(igo.description,"");
            }

            public void OnCreated()
            {
                EditorUtility.SetDirty(this);
                thisText.text = goalTarget.name;
            }
		}	
	}
}
