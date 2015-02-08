using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	GameObject[] arrowImages;
	bool allArrowsFired = false;
	Vector3 menuPos;
	Vector3 hidenPos;
	bool levelCompleted = false;
	RectTransform menu;


	//for swaping UI
	//original UI positions
	RectTransform jumpOrgPos;
	RectTransform leftOrgPos;
	RectTransform rightOrgPos;
	//for saving pos after swap
	RectTransform altJumpPos;
	RectTransform altpRightPos;
	RectTransform altLeftPos;

	Vector3 tempPos;


	bool swapBack = false;

	// Use this for initialization
	void Start () {


		altJumpPos = GameObject.Find("Button_jump").GetComponent<RectTransform>();
		tempPos = altJumpPos.transform.position;;
		altpRightPos = GameObject.Find("Button_right").GetComponent<RectTransform>();
		altLeftPos = GameObject.Find("Button_left").GetComponent<RectTransform>();


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
		//Debug.Log("starting/resuming game");
		menu.transform.position = hidenPos;
		Time.timeScale = 1;
	}
	public void ShowMenu()
	{
		menu.transform.position = menuPos;
		Time.timeScale = 0;

	}

	public void SwapUI()
	{
		Debug.Log("SwapUIBack" + swapBack);
		if(!swapBack)
		   {
			jumpOrgPos = GameObject.Find("Button_jump").GetComponent<RectTransform>();
			leftOrgPos = GameObject.Find("Button_left").GetComponent<RectTransform>();
			rightOrgPos = GameObject.Find("Button_right").GetComponent<RectTransform>();

			GameObject.Find("Button_jump").GetComponent<RectTransform>().transform.position = altpRightPos.transform.position;
			GameObject.Find("Button_jump").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,altJumpPos.transform.eulerAngles.z+180);
				
			GameObject.Find("Button_right").GetComponent<RectTransform>().transform.position = tempPos;
			GameObject.Find("Button_right").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,altpRightPos.transform.eulerAngles.z+180);

			GameObject.Find("Button_left").GetComponent<RectTransform>().transform.position =  new Vector3 ( altJumpPos.transform.position.x, altpRightPos.transform.position.y, altpRightPos.transform.position.z);
			GameObject.Find("Button_left").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,altLeftPos.transform.eulerAngles.z+180);

			swapBack = true;

			jumpOrgPos = GameObject.Find("Button_jump").GetComponent<RectTransform>();
			tempPos = jumpOrgPos.transform.position;
			leftOrgPos = GameObject.Find("Button_left").GetComponent<RectTransform>();
			rightOrgPos = GameObject.Find("Button_right").GetComponent<RectTransform>();
		}
		else
		{

			GameObject.Find("Button_jump").GetComponent<RectTransform>().transform.position = rightOrgPos.transform.position;
			GameObject.Find("Button_jump").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,jumpOrgPos.transform.eulerAngles.z+180);
			
			GameObject.Find("Button_right").GetComponent<RectTransform>().transform.position = tempPos;
			GameObject.Find("Button_right").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,rightOrgPos.transform.eulerAngles.z+180);
			
			GameObject.Find("Button_left").GetComponent<RectTransform>().transform.position =   new Vector3 ( jumpOrgPos.transform.position.x, rightOrgPos.transform.position.y, rightOrgPos.transform.position.z);
			GameObject.Find("Button_left").GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0f,0f,leftOrgPos.transform.eulerAngles.z+180);

			swapBack = false;

			altJumpPos = GameObject.Find("Button_jump").GetComponent<RectTransform>();
			tempPos = altJumpPos.transform.position;;
			altpRightPos = GameObject.Find("Button_right").GetComponent<RectTransform>();
			altLeftPos = GameObject.Find("Button_left").GetComponent<RectTransform>();
		}
	}


}
