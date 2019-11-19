using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
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
				rb.velocity = transform.up * speed;
			}

			else if (timer >= timereset)
			{
				timer = 0;
			}
			else
			{
				rb.velocity = -transform.up * speed;
			}
		}
	}
}
