using UnityEngine;
using System.Collections;

public class VelocityStretch : MonoBehaviour {

    public float verticalEffect;
    public float horizontalEffect;
    public Transform player;
    private Vector3 originScale;
    private float leftRightInterp = 0;

	// Use this for initialization
	void Start () {
        originScale = player.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // finds the velocity for vertical and horizontal
        float verticalVel = player.rigidbody.velocity.y*verticalEffect;
        float horizontalVel = Mathf.Sin(leftRightInterp * Mathf.PI) * horizontalEffect;

        // comptue the new scale based on the original
        float newxScale = originScale.x - originScale.x * verticalVel + originScale.x * horizontalVel;
        float newyScale = originScale.x + originScale.y * verticalVel - originScale.y * horizontalVel;
        float newzScale = originScale.z - originScale.z * verticalVel - originScale.z * horizontalVel;
        player.localScale = new Vector3(newxScale,newyScale,newzScale);
	}

    /* Used to set the fraction from start to end of the left/right movement in order to find the vertical velocity
     * 
     */
    public void LeftRightTime(float time)
    {
        this.leftRightInterp = Mathf.Min(time,1.0f);
        
    }
}
