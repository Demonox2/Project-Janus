using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//health
	public int health = 200;

	public GameObject deathEffect;

	private Rigidbody2D rb;
	private Animator anim;

	// character controller input
	private float HorizontalInput;
	private float VerticalInput;

	//move variables
	public float jumpForce;
	public float speed;

	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping;

	//shoot points
	public Transform firePoint;
	public Transform firePointLeft;
	public GameObject Projectile;
	public GameObject Projectile1;

	//ladder variables
	public float distance;
	public float climbspeed;
	public LayerMask ladderrecog;
	public bool isClimbing;



	bool airborne;


	void Start()
    {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

   
    void Update()
    {
		

		//Basic horizontal Movement

		Movement();
		
		//Jump Logic
		if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space)))
		{
			if (airborne == false)
			{
				isJumping = true;
				jumpTimeCounter = jumpTime;
				rb.velocity = Vector2.up * jumpForce;
				anim.SetTrigger("isJumping");
			}
		}
		//Jump Logic Jump Higher
		if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.Space) && isJumping == true))
		{
			if (jumpTimeCounter > 0)
			{
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
		}

		//Lets go of Jump
		if (Input.GetKeyUp(KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.Space)))
		{
			isJumping = false;
		}

			//airborne check
			if (airborne == false)
		{
			anim.SetBool("isJumping", false);
		}
		else
		{
			anim.SetBool("isJumping", true);
		}

		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

	
		if (Input.GetMouseButtonDown(2))
			{
			//make more efficient next time, definitely no need for 2 instances...
			if (GetComponent<SpriteRenderer>().flipX == false)
			{
				Fire();
			}

			else if (GetComponent<SpriteRenderer>().flipX == true)
			{
				Fire1();
			}
			anim.SetBool("isShooting", true);
		}

		else
		{
			anim.SetBool("isShooting", false);
		}

		//ladder mechanics
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladderrecog);

		if (hitInfo.collider != null)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
			{
				isClimbing = true;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.RightArrow)))
				isClimbing = false;
		}

		if (isClimbing == true && hitInfo.collider != null)
		{
			VerticalInput = Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(rb.velocity.x, VerticalInput * climbspeed);
			rb.gravityScale = 0;
		}
		else
		{
			rb.gravityScale = 1;

		}
	}

	void Movement()//horizontal movement
	{
		HorizontalInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(HorizontalInput * speed, rb.velocity.y);
		//sprite flip logic
		if (Input.GetAxis("Horizontal") > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}

		else if ((Input.GetAxis("Horizontal") < 0))
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	//ground rules
	public void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			airborne = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			airborne = true;
		}
	}

	//shooting
	void Fire()
	{
		Instantiate(Projectile, firePoint.position, firePoint.rotation);
	}
	//fire left
	void Fire1()
	{
		Instantiate(Projectile1, firePointLeft.position, firePointLeft.rotation);
	}

	//damage variable
	public void TakeDamage(int damage)
	{
		health -= damage;//working

		if (health <= 0)
		{
			Die();//not working?
		}
	}

	//Death....not working?
	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Debug.Log("Die");
	}
}
