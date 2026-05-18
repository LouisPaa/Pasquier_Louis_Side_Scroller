using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; // Trouve la position du spawner
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {// pemret de faire réapparaitre le joueur à la position du spawner si il entre en collision avec la zone de mort
        if (collision.CompareTag("Player"))
        {
        collision.transform.position = playerSpawn.position;
          
        }
            
    }
}
