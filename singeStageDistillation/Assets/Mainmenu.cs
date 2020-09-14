using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame ()
    {
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void CheckLab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
	Application.Quit();
    }
}
