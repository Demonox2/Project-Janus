using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	private Transform destination;
    private string ObjectTag;

	public bool isOrange;
	public float distance = 0.3f;

	void Start()
	{
		if(isOrange == false)
		{
			destination = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>();

		}
		else
		{
			destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
		}
	}

	//Portal Detection on Collision
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            if (Vector2.Distance(transform.position, other.transform.position) > 0.3f)
            {
                other.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
        else if (other.gameObject.tag == "Movable")
        {
            if (Vector2.Distance(transform.position, other.transform.position) > 0.1f)
            {
                other.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
		
	}
}
