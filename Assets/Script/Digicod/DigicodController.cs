using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigicodController : MonoBehaviour {

	//Digicod parameters
	public string password;
	public int key;
	private char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

	//Digicod Canvas
	public Text solutionText;
	public Text keyText;
	public Text passwordText;

	// Use this for initialization
	void Start () {
		InitializeDigicod();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeDigicod ()
	{
		GetComponent<Canvas>().enabled = true;
		passwordText.text = CodePassword(password);
	}

	string CodePassword (string pass)
	{
		string codpass = string.Empty;
		for (int i = 0; i < pass.Length; i++) {
			int count = FindLetter (alphabet, pass [i]);
			if (count != -1) {
				if (count - key >= 0) {
					codpass += alphabet [count - key];
				} else {
					codpass += alphabet [alphabet.Length + count - key];
				}
			} else {
				codpass += " ";
			}
		}
		return codpass;
	}

	int FindLetter (char[] alph, char letter)
	{
		int i = 0;
		foreach (char x in alph) 
		{
			if (x.Equals (letter))
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	public void CompareSolutions ()
	{
		if (solutionText.text.Equals (password)) {
			gameObject.GetComponent<Canvas> ().enabled = false;
		}
	}
}
