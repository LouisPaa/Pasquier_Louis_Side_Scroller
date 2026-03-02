using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position; // Fait réapparaitre le joueur à la positon du spawner
            Debug.Log("Le joueur est mort !");
        }
            
    }
}
