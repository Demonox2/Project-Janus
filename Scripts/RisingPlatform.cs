using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public float timer = 0.0f;
	public float deathtime;

	void Start()
	{
		rb.velocity = transform.up * speed;
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= deathtime)
		{
			Destroy(gameObject);
		}
	}
}
