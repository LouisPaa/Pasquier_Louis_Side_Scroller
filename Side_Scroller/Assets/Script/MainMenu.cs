using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public void StartGame() // Permet de charger la scène du jeu lorsque le joueur clique sur le bouton "Start"
    {
        SceneManager.LoadScene(levelToLoad);
    }

    

    public void QuitGame() // Permet de quitter le jeu lorsque le joueur clique sur le bouton "Quit"
    {
        Application.Quit();
    }
}

