using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}
