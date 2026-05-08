using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckPoint : MonoBehaviour
{
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position; // Change la position du spawner pour que le joueur réapparaisse à la position du checkpoint
            Destroy(gameObject); // Detruit le checkpoint pour éviter que le joueur puisse réutiliser ce checkpoint
        }
    }
}
