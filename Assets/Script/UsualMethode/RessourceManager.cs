using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VolarelaNS {
	public static class RessourcesManager{
		///<summary>
		///Return the named Scriptableobject in the root scriptable object folder.
		///</summary>
		///<parm name="name" >Name of the wanted scriptable object</param>
		static public ScriptableObject GetScriptableData(string name) {
			var _ScriptableData = Resources.Load("ScriptableObjects/" + name) as ScriptableObject;
			return _ScriptableData;
		}

		///<summary>
		///Return the named Scriptableobject in the entred folder.
		///</summary>
		///<parm name="name" >Name of the wanted scriptable object</param>
		///<parm name="folder" >Name of the folder that contain the waned scriptable object</param>
		static public ScriptableObject GetScriptableData(string folder, string name) {
			var _ScriptableData = Resources.Load("ScriptableObjects/" + folder + "/" + name) as ScriptableObject;
			return _ScriptableData;
		}

		///<summary>
		///Convert an Object list to another component list. Return null if the targeted type isn't derived from object or if one of the object on the list not fit with the choosen type.
		///</summary>
		static public T[] ConvertObjects<T> (this object[] _objList){
			var _tempList = new T[_objList.Length];
			if(_tempList != null){
			if(_tempList is T[]){
				for (int i = 0; i < _objList.Length; i++)
				{
					_tempList[i] = (T)_objList[i];
				}
				return _tempList;
			}
			}
			return null;
		}
	}


}
