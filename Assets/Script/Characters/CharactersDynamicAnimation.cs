using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VolarelaNS;
using VolarelaNS.IGO;

[AddComponentMenu("")]
public class CharactersDynamicAnimation : MonoBehaviour {

	[HideInInspector]
	public int animRange;

	[HideInInspector]
	public Character chara;
	
	[HideInInspector]
	public Emotions emo;

	Sprite[][] animBank;

	public Image img;
	public Animator anim;
	
	void Start (){

		SetAnim(chara);

	}
	
	void Update () {
		UpdateAnim();
	}

	public void SetAnim(Character _chara)
	{
		animBank = new Sprite[8][]{
			_chara.neutralSprites,
			_chara.angrySprites,
			_chara.proudSprites,
			_chara.mockingSprites,
			_chara.gaySprites,
			_chara.surprisedSprites,
			_chara.happySprites,
			_chara.thinkingSprites,
		};
	}

	private void UpdateAnim (){
		if(anim.GetInteger("int") != (int)emo){
			anim.SetInteger("int",(int)emo);
		}
		if(img.sprite != animBank[(int)emo][animRange]){
			img.sprite = animBank[(int)emo][animRange];
		}
	}
}
