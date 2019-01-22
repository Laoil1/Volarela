using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.Switchs {
	static public class SwitchMethods{
		///<summary>
		///Return the value of the switch named in a list of switch. Return false if the named switch doesnt exist in the list.
		///</summary>
		/// <param name="listOfSwitch">The list that containe the shearched switch</param>
		/// <param name="nameOfSwitch">Name of the searched Switch</param>
		static public bool FindSwitchStateInArray (Switch[] listOfSwitch, string nameOfSwitch){
			for(var i=0; i<listOfSwitch.Length;i++){
				if(listOfSwitch[i].name == nameOfSwitch){
					return listOfSwitch[i].state;
				}
			}
			return false;
		}
		///<summary>
		///Return the switch named in a list of switch. Return an empty false switch if the named switch doesnt exist in the list.
		///</summary>
		/// <param name="listOfSwitch">The list that containe the shearched switch</param>
		/// <param name="nameOfSwitch">Name of the searched Switch</param>

		static public Switch FindSwitchInArray (Switch[] listOfSwitch, string nameOfSwitch){
			for(var i=0; i<listOfSwitch.Length;i++){
				if(listOfSwitch[i].name == nameOfSwitch){
					return listOfSwitch[i];
				}
			}
			return new Switch("",false); 
		}
		///<summary>
		///Return a list of all the switch's names in a switch list. 
		///</summary>

		static public string[] GetAllSwitchName(this Switch[] _switchsList){
			var _string = new string [_switchsList.Length];
			for (int i = 0; i < _switchsList.Length; i++)
			{
				_string[i] = _switchsList[i].name;
			}
			return _string;
		}

	}
}
