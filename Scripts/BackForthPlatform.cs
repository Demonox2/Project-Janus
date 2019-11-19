using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthPlatform : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public float timer;
	public float directiontimer;
	public float timereset;

	void Update()
	{
		timer += Time.deltaTime;

		for (int i = 0; i < timer; i++)
		{
			if (timer <= directiontimer)
			{
				rb.velocity = transform.right * speed;
			}

			else if (timer >= timereset)
			{
				timer = 0;
			}
			else
			{
				rb.velocity = -transform.right * speed;
			}
		}
	}
}
