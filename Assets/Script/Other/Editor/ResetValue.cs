using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VolarelaNS;
using VolarelaNS.IGO;
using VolarelaNS.Switchs;

public class ResetSCRObject : EditorWindow {

[MenuItem("Volarela/Reset")]
	public static void Init(){
		if(GeneralValue.inGameListSwitch!=null){
			foreach (var _switch in GeneralValue.inGameListSwitch)
			{
				_switch.state = _switch.initialState;
			}
		}
		if(GeneralValue.igoData != null){
			foreach (var _obj in GeneralValue.igoData.AllCharacters){
				_obj.isDiscovered = false;
			}
			
			foreach (var _obj in GeneralValue.igoData.AllItems){
				_obj.isDiscovered = false;
			}
			
			foreach (var _obj in GeneralValue.igoData.AllGoals){
				_obj.isDiscovered = false;
			}
		}
	}

}
