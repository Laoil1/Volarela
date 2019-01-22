using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.Switchs{

[CreateAssetMenu(fileName = "SwitchName", menuName = "Volarela/Switch", order = 1)]
	public class Switch :ScriptableObject {
		public bool state;
		public bool initialState;


		///<summary>
		///A switch used to block or to authorize access to ingame event. The default state is false.
		///</summary>
		public Switch (string _name){
			name = _name;
			state = false;
		}
		///<summary>
		///A switch used to block or to authorize access to ingame event.
		///</summary>
		public Switch (string _name, bool _state){
			name = _name;
			state = _state;
		}
	}
}