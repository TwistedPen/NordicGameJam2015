using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	GameObject[] arrowImages;
	bool allArrowsFired = false;
	Vector3 menuPos;
	Vector3 hidenPos;
	bool levelCompleted = false;
	RectTransform menu;
	// Use this for initialization
	void Start () {

		menu = GameObject.Find("Menu_Ingame").GetComponent<RectTransform>();
		menuPos = menu.transform.position;
		hidenPos = new Vector3 (menu.transform.position.x - Screen.width, menu.transform.position.y, menu.transform.position.z);

		HideMenu();
	}
	
	// Update is called once per frame
	void Update () {


	}
	public void HideMenu()
	{
		Debug.Log("starting/resuming game");
		menu.transform.position = hidenPos;
		Time.timeScale = 1;
	}
	public void ShowMenu()
	{
		menu.transform.position = menuPos;
		Time.timeScale = 0;

	}


}
