using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float speed = 3f;
	GameObject player;
	bool hasPassedPlayer = false;
	bool canMove = true;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	void FixedUpdate()
	{
		if(canMove)
			rigidbody.velocity = new Vector3(0f, 0f, -speed);
		else
			rigidbody.velocity = new Vector3(0f, 0f, 0f);
		
	}

	// Update is called once per frame
	void Update () {

		if(transform.position.z < player.transform.position.z && !hasPassedPlayer)
		{
			player.SendMessage("AddScore");
			hasPassedPlayer = true;
		}
	
	}

	void OnTriggerEnter(Collider colInfo)
	{
		//Debug.Log("Obstacle hit trigger with name: " + colInfo.name);
		if(colInfo.gameObject.name == "ObjectDestroyer")
		{
			Destroy(gameObject);
		}
	}

	public void ChangeObjectState()
	{
		if(canMove)
			canMove = false;
		else
			canMove = true;

		//Debug.Log("Obstacle State: " + canMove);
	}
}
