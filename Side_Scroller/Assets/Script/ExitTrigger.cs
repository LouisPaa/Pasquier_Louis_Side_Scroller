using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



     // Nom de la scène à charger lorsque le joueur entre dans le trigger
    public class ExitTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndingScene");

        }
    }
}
