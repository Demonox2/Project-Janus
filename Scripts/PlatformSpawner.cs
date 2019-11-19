using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	public Transform spawnPoint;

	public GameObject platform;

	public float DownTime = 1.0f;

	private float SpawnTimer = 2.0f;


	void Update()
	{
		if (Time.time >= SpawnTimer)
		{
			SpawnPlatform();
			SpawnTimer = Time.time + DownTime;
		}
	}

	void SpawnPlatform()
	{
		Instantiate(platform, spawnPoint.position, Quaternion.identity);
	}
}
