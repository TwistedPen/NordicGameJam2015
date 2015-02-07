using UnityEngine;
using System.Collections;

public class TandhjulRoter : MonoBehaviour {

	[SerializeField] private float retning;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate (0f, 1f * retning, 0f);	
	}
}
