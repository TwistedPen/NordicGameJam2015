using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 20f;
	public float jumpForce = 20f;

	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 1f;
	public LayerMask WhatIsGround;//for checking if it something player can stand on

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		//check if it hit something			where circle is		its radius		things it collide with
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
				
		//move characted based on direction input and max speed
		float move = Input.GetAxis("Horizontal");
		
		rigidbody.velocity = new Vector3(0f, 0f, maxSpeed);
		//rigidbody.velocity = new Vector3(rigidbody.velocity.y, rigidbody.velocity.y, maxSpeed);

	}

	// Update is called once per frame
	void Update () {
	
		//Jump if jump button is pressed and character is on the ground
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			//add the upward force to make player jump
			rigidbody2D.AddForce(new Vector2(0f,jumpForce));
			
			//makes sure player cannot double jump infinite times
			if(!grounded)
				canDoubleJump = false;
		}
	}
}