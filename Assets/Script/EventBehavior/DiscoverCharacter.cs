using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VolarelaNS
{
	using IGO;
	namespace EventVol
	{
		public class DiscoverCharacter : MonoBehaviour 
		{
			
			public IGOChoices igoType;
	
			public int coIndex;

			public int changerdObject;

			public void SetDiscovered ()
			{
				switch (igoType)
				{
					case IGOChoices.Character :
						GeneralValue.igoData.AllCharacters[changerdObject].isDiscovered = true;
						break;
					
					case IGOChoices.Item :
						GeneralValue.igoData.AllItems[changerdObject].isDiscovered = true;
						break;

					case IGOChoices.Goal :
						GeneralValue.igoData.AllGoals[changerdObject].isDiscovered = true;
						break;
				}
			}

		}
		
	}

}