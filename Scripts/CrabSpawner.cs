using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour
{

	public Transform spawnPoint;

	public GameObject Crab;

	public float DownTime = 1.0f;

	private float SpawnTimer = 2.0f;

	void Start()
    {
        
    }

    
    void Update()
    {
		if (Time.time >= SpawnTimer)
		{
			SpawnCrab();
			SpawnTimer = Time.time + DownTime;
		}
	}

	void SpawnCrab()
	{
		//turns out you can spawn more than just crab as its a variable
		//won't change not cause it works and i'm starting to get tired @ 4:20 a.m. - Dom. S
		Instantiate(Crab, spawnPoint.position, Quaternion.identity);
	}
}
