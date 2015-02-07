using UnityEngine;
using System.Collections;

public class Menu_Main_ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void StartGame()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
}
