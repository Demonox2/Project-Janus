﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public float timer = 0.0f;
	public float deathtime;
	public float turntimer;

	void Start()
	{
		rb.velocity = -transform.right * speed;
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