using UnityEngine;
using System.Collections;

public class VelocityStretch : MonoBehaviour {

    public float effect;
    public Transform player;
    private Vector3 originScale;

	// Use this for initialization
	void Start () {
        originScale = player.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float veloc = player.rigidbody.velocity.y*effect;
        player.localScale = new Vector3(originScale.x - originScale.x * veloc,originScale.y + originScale.y*veloc,originScale.z - originScale.z*veloc);
        
	}
}
