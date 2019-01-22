using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using testNamespacez;

public static class testStatic {

	static public string[] ntm (this TPSObject[] tpsO){
		string[] _tempList = new string[tpsO.Length];
		for (var i = 0; i< tpsO.Length; i++){
		
			_tempList [i] = tpsO [i].name;
		
		}

		return _tempList;
	}

}
