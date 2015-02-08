﻿using UnityEngine;
using System.Collections;

public class IntroAnimationManager : MonoBehaviour {

	[SerializeField] private Animator sphere;
	[SerializeField] private Animator machine;
	[SerializeField] private IntroTetrisSpawn tetrisSpawn;
	[SerializeField] private GameObject ui;

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			BeginGame();
		}
	}

	void BeginGame()
	{
		sphere.Play ("spawn_player");
		machine.Play ("amok");
		tetrisSpawn.CancelProduction ();
		Invoke ("ChangeLevel", 5f);
		ui.SetActive (false);
		audio.Play ();
	}

	void ChangeLevel()
	{
		Application.LoadLevel (1);
	}

}
