using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour
{
	public float timer = 0.0f;
	public float speed = 20.0f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject Impact;
	

	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	//timed destroy
	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= 0.9f)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
			Instantiate(Impact, transform.position, Quaternion.identity);
		}

		if (hitInfo.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			Instantiate(Impact, transform.position, Quaternion.identity);
		}

		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
	}
}