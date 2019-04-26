using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffects : MonoBehaviour
{

	public float timer = 0.0f;

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= 0.9f)
		{
			Destroy(gameObject);
		}
	}
}
