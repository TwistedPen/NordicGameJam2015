using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	GameObject[] arrowImages;
	bool allArrowsFired = false;
	Vector3 menuPos;
	bool levelCompleted = false;

	// Use this for initialization
	void Start () {
	
		HideMenu();
	}
	
	// Update is called once per frame
	void Update () {


	}
	public void HideMenu()
	{
		RectTransform menu = GameObject.Find("Menu_Ingame").GetComponent<RectTransform>();
		menuPos = menu.transform.position;
		menu.transform.position = new Vector3 (menu.transform.position.x - Screen.width, menu.transform.position.y, menu.transform.position.z);
		Time.timeScale = 1;
	}
	public void ShowMenu()
	{
		RectTransform menu = GameObject.Find("Menu_Ingame").GetComponent<RectTransform>();
		menu.transform.position = menuPos;
		Time.timeScale = 0;

	}


}
