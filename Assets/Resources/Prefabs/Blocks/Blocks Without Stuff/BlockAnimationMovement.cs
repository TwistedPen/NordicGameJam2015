using UnityEngine;
using System.Collections;

public class BlockAnimationMovement : MonoBehaviour {

	void FixedUpdate ()
	{
		Vector3 position = transform.position;
		position.z += -0.013f;
		transform.position = position;
	}
}
