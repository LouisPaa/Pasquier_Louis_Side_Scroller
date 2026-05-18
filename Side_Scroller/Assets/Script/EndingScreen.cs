using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class EndingScreen : MonoBehaviour
{
   public void OnTitleScreenClick() // Permet de retourner au menu principal lorsque le joueur clique sur le bouton "Title Screen"
    {
        SceneManager.LoadScene("StartScene");
    }
}
