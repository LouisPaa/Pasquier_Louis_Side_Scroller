using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; // Trouve la position du spawner
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        collision.transform.position = playerSpawn.position;
            Debug.Log("Le joueur est mort !");
        }
            
    }
}
