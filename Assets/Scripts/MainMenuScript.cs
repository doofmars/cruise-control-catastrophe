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

    public void showHowTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void showCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void startGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void showMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
