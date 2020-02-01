using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string sceneName;


    public void exitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void showSettings()
    {

    }

    public void showCredits()
    {

    }

    public void startGame()
    {
        SceneManager.LoadScene(sceneName);
    }

}
