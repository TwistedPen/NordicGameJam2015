using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{

		rigidbody.velocity = new Vector3(0f, 0f, -speed);
		
	}

	// Update is called once per frame
	void Update () {
	
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
