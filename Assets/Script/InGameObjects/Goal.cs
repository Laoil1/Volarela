using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolarelaNS.Switchs;

namespace VolarelaNS.IGO {

	[System.Serializable]
	public class Goal : InGameObjectBase {
        [Header("Goals Parameters")]
		public bool isValidate;

		public Goal(string _name){
			name = _name;
		}
	}
}