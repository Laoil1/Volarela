using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteController : MonoBehaviour {

	public Color color = Color.white;
	public float outlineSize = 1f;

	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void OnEnable () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter ()
	{
		UpdateOutline(true);
	}

	void OnMouseExit()
	{
		UpdateOutline(false);
	}

	void UpdateOutline (bool outline)
	{
		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		spriteRenderer.GetPropertyBlock(mpb);
		mpb.SetFloat("_Outline", outline ? 	1f : 0f);
		mpb.SetColor("_OutlineColor", color);
		mpb.SetFloat("_OutlineSize", outlineSize);
		spriteRenderer.SetPropertyBlock(mpb);
	}
}
