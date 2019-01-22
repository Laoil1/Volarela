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
		if(Resources.LoadAll("ScriptableObjects/InGameObjects").ConvertObjects<InGameObjectBase>()!= null){
			foreach (var _obj in Resources.LoadAll("ScriptableObjects/InGameObjects").ConvertObjects<InGameObjectBase>()){
				_obj.isDiscovered = false;
			}
		}
	}

}
