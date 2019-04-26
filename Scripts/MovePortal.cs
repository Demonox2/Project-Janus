using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortal : MonoBehaviour
{

	private Vector2 target;
	private Transform bluePortal;
	private Transform orangePortal;

	void Start()
	{
		bluePortal = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
		orangePortal = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>();
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			bluePortal.position = new Vector2(target.x, target.y);
		}

		else if(Input.GetMouseButtonDown(1))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			orangePortal.position = new Vector2(target.x, target.y);
		}
	}

}
