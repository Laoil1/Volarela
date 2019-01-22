using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VolarelaNS.IGO;

public interface IMenuButton 
{
	InGameObjectBase target 
	{
		get;
		set;
	}
	Image ThisImg 
	{
		get; 
		set;
	}
	Text ThisText 
	{	
		get; 
		set;
	}

	void OnClickSetMenu();

	void OnCreated();

	
}
