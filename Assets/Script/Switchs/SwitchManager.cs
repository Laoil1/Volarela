using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VolarelaNS.Switchs;

namespace VolarelaNS.NotEditable{

	[System.Serializable]
	public struct condition{
		public Switch _switch;
		public bool conditionState;
	}

	public class SwitchManager : MonoBehaviour {
		public bool atStart;
		public bool atUpdate;
		public bool atTrigger;
		public bool atClick;
		public condition[] Conditions;
		public UnityEvent Consequences;

		// Use this for initialization
		void Start(){
			if (atStart)
			LauncheConsequences();
		}
		// Update is called once per frame
		void Update () {
			if(atUpdate)
			LauncheConsequences();
		}

		void OnTriggerEnter ()
		{
			if(atTrigger)
			{
				LauncheConsequences();
			}
		}

		void OnMouseDown()
		{
			if(atClick)
			{
				LauncheConsequences();
			}
		}
		
		///<summary>
		///Return true if all the conditions are true. Return false otherway.
		///</summary>

		bool AreConditionsOkay (){
			var _check = true;
			
			foreach (var _cond in Conditions){
				if(_cond.conditionState != _cond._switch.state){
					_check = false;
					break;
				}
			}
			
			return _check;
		}

		void LauncheConsequences(){
			if(AreConditionsOkay()){
				Consequences.Invoke();
			}
		}
	}

}