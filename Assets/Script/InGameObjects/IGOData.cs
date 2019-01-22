using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS {

using IGO;

	[CreateAssetMenu(fileName="Character Name",menuName ="Volarela/IGO/Data",order=1)]
	public class IGOData : ScriptableObject {

		public Character[] AllCharacters;
		public Goal[] AllGoals;
		public Item[] AllItems;

	}
}
