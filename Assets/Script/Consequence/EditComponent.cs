using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolarelaNS;

namespace VolarelaNS.NotEditable{
	public class EditComponent : MonoBehaviour {

		public bool wantedState;
		
		public string target;
		[HideInInspector]	
		public int targetIndex;
		[HideInInspector]	

		public string[] choices;

		public void ChangeState (bool state){
			var comp = gameObject.GetComponent(target) as Behaviour;
			comp.enabled = state;
		}
	}

}