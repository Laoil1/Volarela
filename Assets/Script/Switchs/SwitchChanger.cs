using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolarelaNS.Switchs;

namespace VolarelaNS.NotEditable{
	public class SwitchChanger : MonoBehaviour {


		public void SetSwitchTrue (Switch _switch){
			_switch.state = true;
		}

		public void SetSwitchFalse (Switch _switch){
			_switch.state = false;
		}

		public void ChangeSwitchState (Switch _switch){
			_switch.state = !_switch.state;
		}
	}
}