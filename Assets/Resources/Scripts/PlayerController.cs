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
	int score = 0;

	//lane change (Lerp)
	Vector3 startMarker;
	Vector3 endMarker;
	float speed = 10.0F;
	float startTime;
	float journeyLength;
	bool changingLane = false;
	
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {

		//Jump if jump button is pressed and character is on the ground
		if(grounded && Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
		{
			//add the upward force to make player jump
			rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
			//Debug.Log("player jumped");
			Audio.Play(SoundEvent.Jump);
			grounded = false;

		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveLeft();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveRight();
		}

		//lane swap lerp
		if(changingLane)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
		}
		
	}

	void OnCollisionEnter(Collision colInfo)
	{

		if(colInfo.gameObject.name == "Floor")
		{
			Audio.Play(SoundEvent.Land);
			grounded = true;
		}
	}

	void OnTriggerEnter(Collider colInfo)
	{
		if(colInfo.gameObject.tag == "Obstacle")
		{
			//Debug.Log("Player hit Obstacle: " + colInfo.gameObject.name);

			//Update UI
			numError++;
			Text[] ErrorTexts = GameObject.Find("Text_Error").GetComponentsInChildren<Text>();
			for (int i = 0 ; i < ErrorTexts.Length; i++)
			{
				if(ErrorTexts[i].gameObject.name == "Number")
					ErrorTexts[i].text = numError.ToString();
			}

			Audio.Play(SoundEvent.Collide);

			//Show Menu
			GameObject.Find("UI").SendMessage("ShowMenu");
		}
	}

	public void AddScore()
	{
		//Debug.Log("player cleared an obstacle");

		score++;
		Text[] scoreTexts = GameObject.Find("Text_Score").GetComponentsInChildren<Text>();
		for (int i = 0 ; i < scoreTexts.Length; i++)
		{
			if(scoreTexts[i].gameObject.name == "Number")
				scoreTexts[i].text = score.ToString();
		}
	}
	
	public void MoveRight()
	{
		if(transform.position.x < 1f)
		{
			startMarker = transform.position;
			endMarker = new Vector3(transform.position.x+1.5f,transform.position.y,transform.position.z);
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker, endMarker);
			changingLane = true;

			Audio.Play(SoundEvent.Move);

			//transform.Translate(new Vector3 (1.5f,0f, 0f));
		}
			
	}
	public void MoveLeft()
	{
		if(transform.position.x > -1f)
		{
			startMarker = transform.position;
			endMarker = new Vector3(transform.position.x-1.5f,transform.position.y,transform.position.z);
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker, endMarker);
			changingLane = true;
			Audio.Play(SoundEvent.Move);

			//transform.Translate(new Vector3 (-1.5f,0f, 0f));
		}
	}
	public void Jump()
	{
		//Debug.Log("player jumped called" + grounded);
		//Jump if jump button is pressed and character is on the ground
		if(grounded && Time.timeScale == 1)
		{
			//add the upward force to make player jump
			rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
			//Debug.Log("player jumped");
			grounded = false;
			Audio.Play(SoundEvent.Jump);

		}
	}
}

