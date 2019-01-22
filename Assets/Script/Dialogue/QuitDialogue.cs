using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuitDialogue : MonoBehaviour {

	public UnityEvent Consequences;
	public void QuitDialogueButton()
	{
		Consequences.Invoke();
	}
}
