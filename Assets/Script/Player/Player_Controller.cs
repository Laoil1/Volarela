using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour {

	//Variables for PlayerMovement()
	public bool canWalk;
	private CharacterController characterController;
	public float speed = 10f;

	//Variables for Aspect()
	private SpriteRenderer spriteRenderer;
	public Sprite playerIcone;
	public float heightIcone;

	//Variables for CameraController()
	private Camera playerCamera;
	public float heightCamera;

	//Variables for OnMouseOver & OnMouseExit
	public MeshRenderer meshRenderer;
	public float outline = 0f;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		characterController = GetComponent<CharacterController>();
		playerCamera = GetComponentInChildren<Camera>();
		meshRenderer = GetComponent<MeshRenderer>();

		Aspect(playerIcone, heightIcone);
		Camera(playerCamera,heightCamera);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (canWalk) {
			characterController.Move(PlayerMovement ());
		}
	}

	public Vector3 PlayerMovement ()
	{
		Vector3 movementValues = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		movementValues = transform.TransformDirection(movementValues);

		movementValues *= Time.deltaTime * speed;

		return (movementValues);
	}

	public void Aspect (Sprite sprite, float height)
	{
		spriteRenderer.sprite = sprite;
		spriteRenderer.gameObject.transform.position += new Vector3 (0,height,0);
	}

	public void Camera (Camera camera, float height)
	{
		camera.gameObject.transform.position += new Vector3 (0,height,0);
	}

	void OnMouseOver ()
	{
		meshRenderer.materials[1].SetFloat("_Outline", outline);
	}

	void OnMouseExit ()
	{
		meshRenderer.materials[1].SetFloat("_Outline", 0f);
	}
}
