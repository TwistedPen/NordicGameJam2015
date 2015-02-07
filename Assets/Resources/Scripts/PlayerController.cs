using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 20f;
	public float jumpForce = 200f;

	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask WhatIsGround;//for checking if it something player can stand on

	int numError = 0;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		//check if it hit something			where circle is		its radius		things it collide with
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		

		//Jump if jump button is pressed and character is on the ground
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			//add the upward force to make player jump
			rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
			//Debug.Log("player jumped");
			Audio.Play(SoundEvent.Jump);
			grounded = false;

		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			//Audio.Play(SoundEvent.Jump);
			MoveLeft();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			//Audio.Play(SoundEvent.Jump);
			MoveRight();
		}

	}

	void OnCollisionEnter(Collision colInfo)
	{

		//Debug.Log("Player hit: " + colInfo.gameObject.name);

		if(colInfo.gameObject.name == "Floor")
			grounded = true;

	}

	void OnTriggerEnter(Collider colInfo)
	{
		if(colInfo.gameObject.tag == "Obstacle")
		{
			Debug.Log("Player hit Obstacle: " + colInfo.gameObject.name);

			numError++;
			GameObject.Find("Number").GetComponent<Text>().text = numError.ToString();

			Audio.Play(SoundEvent.Collide);

		}
	}

	public void MoveRight()
	{
		if(transform.position.x < 1f)
		{
			Audio.Play(SoundEvent.Move);

			transform.Translate(new Vector3 (1.5f,0f, 0f));
		}
			
	}
	public void MoveLeft()
	{
		if(transform.position.x > -1f)
		{
			Audio.Play(SoundEvent.Move);

			transform.Translate(new Vector3 (-1.5f,0f, 0f));
		}
	}
	public void Jump()
	{
		Debug.Log("player jumped called" + grounded);
		//Jump if jump button is pressed and character is on the ground
		if(grounded)
		{
			//add the upward force to make player jump
			rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
			Debug.Log("player jumped");
			grounded = false;
			Audio.Play(SoundEvent.Jump);

		}
	}
}