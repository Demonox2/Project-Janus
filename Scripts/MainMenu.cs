using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void RestartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}
}
