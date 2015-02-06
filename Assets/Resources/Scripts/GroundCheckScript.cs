using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {

	public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(ball.position.x,ball.position.y - 2.5f,ball.position.z);
	}
}
