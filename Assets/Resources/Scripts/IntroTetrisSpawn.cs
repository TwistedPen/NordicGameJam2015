﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntroTetrisSpawn : MonoBehaviour {

	[SerializeField] private GameObject[] pieces;

	private List<GameObject> instantiatedPieces;
	
	void Start () 
	{
		audio.Play ();

		instantiatedPieces = new List<GameObject>();
		InvokeRepeating ("SpawnTetris", 0f, 4f);
		InvokeRepeating ("PlaySound", 2.5f, 4f);
	}

	void PlaySound()
	{
		audio.Play ();
	}

	void SpawnTetris()
	{
		instantiatedPieces.Add((GameObject) Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
	}

	public void CancelProduction()
	{
		CancelInvoke ("SpawnTetris");
		CancelInvoke ("PlaySound");
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
