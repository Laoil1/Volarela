using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS.IGO{
	[System.Serializable]
	public class InGameObjectBase  {

		public string name;


		//Description of the object
		[TextArea]
		public string description;

		[Header("Dont Touch except in PlayMode")]
		//Is the 
		public bool isDiscovered;

	}

}