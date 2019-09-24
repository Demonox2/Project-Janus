using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

	public TextMeshProUGUI textDisplay;
	public string[] sentences; //array for sentences
	private int index;
	public float typingSpeed;

	public GameObject continueButton; //to avoid spamming click through dialogue

    void Start()
    {
		StartCoroutine(Type());
    }

	void Update()
	{
		if(textDisplay.text == sentences [index]) //if sentence is fully typed out
		{
			continueButton.SetActive(true); //display continue button
		}
	}

	IEnumerator Type()
	{

		foreach(char letter in sentences [index].ToCharArray())
		{
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}

	}

	public void NextSentence()
	{

		continueButton.SetActive(false); //hide continue button

		if(index < sentences.Length -1)
		{
			index++;
			textDisplay.text = ""; //reset text display
			StartCoroutine(Type()); //start next sentence
		}

		else
		{
			textDisplay.text = ""; //reset text display if dialogue is complete
			continueButton.SetActive(false);
		}
	}
 
}
