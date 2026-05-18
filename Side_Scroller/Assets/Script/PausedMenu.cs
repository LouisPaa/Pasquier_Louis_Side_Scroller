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
    {// Permet d'afficher le menu de pause en appuyant sur la touche "Echap"
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

    public void ResumeButton() // Permet de reprendre le jeu lorsque le joueur clique sur le bouton "Resume"
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton() // Permet de retourner au menu principal lorsque le joueur clique sur le bouton "Main Menu"
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OptionsButton() // Permet d'afficher le menu des options lorsque le joueur clique sur le bouton "Options"
    {
        
        container.SetActive(false);
        OptionsMenu.SetActive(true);

    }

}
