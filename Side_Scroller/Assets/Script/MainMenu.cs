using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}

