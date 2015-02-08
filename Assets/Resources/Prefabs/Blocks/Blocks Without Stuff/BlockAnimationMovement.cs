using UnityEngine;
using System.Collections;

public class BlockAnimationMovement : MonoBehaviour {

	private bool played;

	void FixedUpdate ()
	{
		Vector3 position = transform.position;
		position.z += -0.013f;
		transform.position = position;
	}

	void OnCollisionEnter(Collision other)
	{
		if(!played && other.transform.name == "baand" || !played && other.transform.name == "takker") 
		{
			Audio.Play(SoundEvent.Land);
			played = true;
		}
	}
}
