using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{

	private PlatformEffector2D effector; //utilizes unity's built in 2d effector
	public float waitTime; //time between down arrow pressed

    void Start()
    {
		effector = GetComponent<PlatformEffector2D>(); //initializes effector
    }

   
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow) || (Input.GetKeyUp(KeyCode.S)))
		{
			waitTime = 0.05f; 
		}

		if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S)))
		{
			if(waitTime <= 0)
			{
				effector.rotationalOffset = 270f; //rotate effector collision when down key is pressed
				waitTime = 0.05f;
			}

			else
			{
				waitTime -= Time.deltaTime;
			}
		}

		if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.Space)))
		{
			effector.rotationalOffset = 90f; //rotate effector collision to default when jump is pressed
		}
	}
}
