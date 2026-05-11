using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject OptionsMenu;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Escape))
        {
            container .SetActive(true);
            Time.timeScale = 0f;
        }*/
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsMenu.activeSelf)
            {
                OptionsMenu.SetActive(false);
                container.SetActive(true);
            }
            else if (container.activeSelf)
            {
                container.SetActive(false);
                Time.timeScale = 1f;
            }

            else
            {
                container.SetActive(true);
                    Time.timeScale = 0f;
            }
        }

       /* else
        {
            container.SetActive(false);
                Time.timeScale = 0f;
        }*/
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
        
        container.SetActive(false);
        OptionsMenu.SetActive(true);

    }

}
