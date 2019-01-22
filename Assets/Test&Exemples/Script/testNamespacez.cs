using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace testNamespacez{
	[System.Serializable]
	public struct TPSObject {
		public string name;
		public string TPS;

		public TPSObject (string n, string t){
		
			name = n;
			TPS = t;

		}

	}

}
