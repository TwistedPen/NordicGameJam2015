using UnityEngine;
using System.Collections;

public class Menu_InGameMenu_ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

//	public void NextLevel()
//	{
//		if(Application.loadedLevel+1 <= Application.levelCount)
//			Application.LoadLevel(Application.loadedLevel+1);
//		else
//			Application.LoadLevel("Main_Menu");
//	}
	
	public void Replay()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void MainMenu()
	{
		Application.LoadLevel("Main_Menu");
	}
}
