using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2;
	bool canSpawn = true;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		if(canSpawn){

			int randNr = Random.Range(0,4);
			if(randNr > 2)
			  {
				Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z), transform.rotation);
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}
			else if(randNr > 1)
			{
				Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}
			else
			{
				Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z),new Quaternion(transform.rotation.x-90,90,transform.rotation.z,1f));
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}

		}
	}

	public void ChangeSpawnState()
	{
		if(canSpawn)
			canSpawn = false;
		else
		{
			canSpawn = true;
			Spawn();
		}
	}
}
