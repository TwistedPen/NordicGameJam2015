using UnityEngine;
using System.Collections;

public class SideCameraController : MonoBehaviour {

	public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(ball.position.x,ball.position.y-1f,ball.position.z);
	}
}
