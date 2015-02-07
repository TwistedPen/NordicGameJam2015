using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float speed = 3f;
	GameObject player;
	bool hasPassedPlayer = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	void FixedUpdate()
	{

		rigidbody.velocity = new Vector3(0f, 0f, -speed);
		
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
}
