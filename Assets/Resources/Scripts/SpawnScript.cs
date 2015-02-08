using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2;
	bool canSpawn = true;
	int obstaclesSpawned = 0;

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
			obstaclesSpawned++;

            
            // chance to rotate the block around the Y-axis(local x-Axis)
            int rotRand = Random.Range(0, 3);
            Quaternion blockRotation;
           
            if(rotRand >= 1)
                blockRotation = (transform.rotation * Quaternion.Euler(0, 0, 180));
            else
                blockRotation = transform.rotation;
			int randNr = Random.Range(0,5);
			if(randNr > 2)
			{
                Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), blockRotation);
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}
			else if(randNr > 1)
			{
                Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), blockRotation);    
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}
			else
			{
                if(Random.Range(0, 2) == 1)
                    Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), new Quaternion(blockRotation.x - 90, blockRotation.y + 90, blockRotation.z, 1.0f));
                else
                    Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), new Quaternion(blockRotation.x - 90, blockRotation.y - 90, blockRotation.z, 1.0f));
				Invoke("Spawn", Random.Range(spawnMin, spawnMax));
			}


		 if(obstaclesSpawned%10 == 0)
			{
				canSpawn = false;
			}
		}
	}
	

	public void SpawnState(bool state)
	{
		Debug.Log("Spawn State: " + state);
		canSpawn = state;

		if(canSpawn)
			Invoke("Spawn", Random.Range(spawnMin, spawnMax));

	}

}
