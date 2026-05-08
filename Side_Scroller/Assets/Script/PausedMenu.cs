using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject container;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container .SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OptionsButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("OptionsScene");
        
    }

}
