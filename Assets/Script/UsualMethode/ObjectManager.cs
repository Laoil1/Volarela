using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VolarelaNS {
	using IGO;
	public static class ObjectManager{
		///<summary>	
		///Return a list ofstring that contain all the names of the target's members.
		///</summary>	
		public static string[] GetAllName(this Object[] _obj){
			var _stringArray = new string[_obj.Length];
			if(_obj != null){
				for (int i = 0; i < _obj.Length; i++)
				{
					_stringArray[i] = _obj[i].name;
				}
				return _stringArray;
			}else
				Debug.LogError("The target Array is Empty");
			return null;
		}

				///<summary>	
		///Return a list ofstring that contain all the names of the target's members.
		///</summary>	
		public static string[] GetAllNameIGO(this InGameObjectBase[] _obj){
			var _stringArray = new string[_obj.Length];
			if(_obj != null){
				for (int i = 0; i < _obj.Length; i++)
				{
					_stringArray[i] = _obj[i].name;
				}
				return _stringArray;
			}else
				Debug.LogError("The target Array is Empty");
			return null;
		}
	}
}
