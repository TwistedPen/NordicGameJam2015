using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntroTetrisSpawn : MonoBehaviour {

	[SerializeField] private GameObject[] pieces;

	private List<GameObject> instantiatedPieces;

	void Start () 
	{
		instantiatedPieces = new List<GameObject>();
		InvokeRepeating ("SpawnTetris", 0f, 4f);
	}

	void SpawnTetris()
	{
		instantiatedPieces.Add((GameObject) Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
	}

	void Update()
	{
		foreach(GameObject g in instantiatedPieces)
		{
			if(g.transform.position.y < -5)
			{
				instantiatedPieces.Remove(g);
				Destroy(g);
				break;
			}
		}
	}
}
