using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 20f;
	public float jumpForce = 200f;
    public float bounceForce = 200f;

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
    public VelocityStretch vs;
    [SerializeField]
    private FloorAnimationController fac;

	//for gameover
	bool canControl = true;
	bool panOut = true;

	//for camera swap
	bool haveSwaped = false;
	Vector3 playerVelocity;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if(canControl)
		{
			//Jump if jump button is pressed and character is on the ground
			if(grounded && Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
			{
				//add the upward force to make player jump
				//Debug.Log("jumping - Time.timeScale: " + Time.timeScale);
				Jump();

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
                if (vs != null)
                    vs.LeftRightTime(fracJourney);

				if(transform.position == endMarker)
				{
					changingLane = false;
				}
			}
		}
		
	}

	void OnCollisionEnter(Collision colInfo)
	{

		if(colInfo.gameObject.name == "Floor")
		{
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector3(0f, bounceForce, 0f));
			Audio.Play(SoundEvent.Land);
			grounded = true;
		}
	}

	void OnTriggerEnter(Collider colInfo)
	{
		if(colInfo.gameObject.tag.Contains("Obstacle"))
		{
			StartCoroutine(PanCameras());

			Audio.Play(SoundEvent.Collide);
		}
	}

	void ChangeControlState()
	{
		if(canControl)
		{
			//gameObject.rigidbody.velocity = new Vector3 (0f,0f,0f);
			playerVelocity = rigidbody.velocity;
			gameObject.rigidbody.isKinematic = true;
			
			canControl = false;
		}
		else
		{
			gameObject.rigidbody.isKinematic = false;
			rigidbody.velocity = playerVelocity;
			canControl = true;
		}

	}
	IEnumerator PanCameras()
	{
		ChangeControlState();
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for (int i = 0; i< obstacles.Length; i++)
		{
			obstacles[i].SendMessage("ChangeObjectState");
		}

        fac.StopAnimation();

		//GameObject.Find("ObjecSpawner_layingDown").SendMessage("ChangeSpawnState");
		GameObject.Find("ObjecSpawner").SendMessage("ChangeSpawnState");

		if(panOut)
		{
			GameObject.Find("Camera_Portrait_left").SendMessage("GameOver");
			GameObject.Find("Camera_Portrait_top").SendMessage("GameOver");

			yield return new WaitForSeconds(5f);
			
			GameObject.Find("UI").SendMessage("ShowMenu");
		}
//		if we can continue to work
//		else
//		{
//			GameObject.Find("Camera_Portrait_left").SendMessage("ReturnToOrigin");
//			GameObject.Find("Camera_Portrait_top").SendMessage("ReturnToOrigin");
//		}

	}

	IEnumerator SwapCameras()
	{
		ChangeControlState();
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		for (int i = 0; i< obstacles.Length; i++)
		{
			obstacles[i].SendMessage("ChangeObjectState");
		}
	

		if(!haveSwaped)
		{
			GameObject.Find("UI").SendMessage("SwapUI");
			GameObject.Find("Camera_Portrait_left").SendMessage("Swap");
			GameObject.Find("Camera_Portrait_top").SendMessage("Swap");
			yield return new WaitForSeconds(4f);
			GameObject.Find("ObjecSpawner").SendMessage("ChangeSpawnState");
			haveSwaped = true;
			Audio.Play(SoundEvent.Swap);
			StartCoroutine(SwapCameras());
		}
		
		yield return new WaitForSeconds(0f);
		
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
		Audio.Play(SoundEvent.Reward);


		if(score%10 == 0)
		{
			haveSwaped = false;
			StartCoroutine(SwapCameras());
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
            rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
			//Debug.Log("player jumped");
			grounded = false;
			Audio.Play(SoundEvent.Jump);

		}
	}
}

