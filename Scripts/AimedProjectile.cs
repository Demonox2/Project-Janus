using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile: MonoBehaviour
{
	public float speed = 20.0f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject Impact;

	private Transform player;
	private Vector2 target;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		target = new Vector2(player.position.x, player.position.y);
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
			Instantiate(Impact, transform.position, Quaternion.identity);
		}

		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
			Instantiate(Impact, transform.position, Quaternion.identity);
		}
		/*Enemy enemy = collision.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		*/

		PlayerController player = collision.GetComponent<PlayerController>();
		if (player != null)
		{
			player.TakeDamage(damage);
		}

	}
}
