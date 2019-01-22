using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS {
	using Switchs;
	using IGO;
		static public class GeneralValue{
			public static Switch[] inGameListSwitch = Resources.LoadAll("ScriptableObjects/Switchs").ConvertObjects<Switch>();

			public static Character[] allCharacters = Resources.LoadAll("ScriptableObjects/InGameObjects/Characters").ConvertObjects<Character>();
			public static Goal [] allGoal = Resources.LoadAll("ScriptableObjects/InGameObjects/Goals").ConvertObjects<Goal>();
			public static Item[] allItems = Resources.LoadAll("ScriptableObjects/InGameObjects/Items").ConvertObjects<Item>();

			public static IGOData igoData = RessourcesManager.GetScriptableData("Data") as IGOData;
		}
}




