using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using testNamespacez;
using VolarelaNS.Switchs;

public class SomeClass : MonoBehaviour {

	//[HideInInspector]
	[SerializeField]
	public Switch choice;
	public string cc;

	[HideInInspector]
	public int index;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
/*		switch (choice){
		
		case "foo":
			print ("ha bha ça alors");
			break;
		case "foobar":
			print ("ha bha ça alors bar");
			break;
		default : 
			print ("to");
			break;
		}
		*/
	}
}
