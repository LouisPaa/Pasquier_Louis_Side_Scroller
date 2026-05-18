using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartmenuController : MonoBehaviour
{
  public void OnStartClick() // Permet de charger la scène du jeu lorsque le joueur clique sur le bouton "Start"
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void OnExitClick() // Permet de quitter le jeu lorsque le joueur clique sur le bouton "Quit"
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
       
}
