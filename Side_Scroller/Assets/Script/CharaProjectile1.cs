using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharaProjectile1 : MonoBehaviour
{
   [SerializeField] private Transform projectileSpawnPoint;
   [SerializeField] private GameObject projectilePrefab;
   [SerializeField] private float projectileSpeed = 10f;
 //  [SerializeField] private float projectileLifetime = 5f;
   [SerializeField] private float ShootDelay = 0.5f;
   [SerializeField] private float maxDistance = 5f;
    private Animator Animation;
    private string Vague = "Vague";
    float lastDirection = 1f;
    float inputX;
    // Update is called once per frame
    void Update()
    {
        // Permet de récupérer la direction du joueur pour que le projectile soit lancé dans la bonne direction
        float inputX = Input.GetAxisRaw("Horizontal"); 

        if (inputX != 0)
        {
            lastDirection = inputX;
        }

        // Permet de tirer un projecctile
        if (Input.GetButtonDown("Fire2")) 
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(lastDirection* projectileSpeed,0f);
            if (lastDirection < 0)
            {
                projectile.transform.localScale = new Vector3(-1f, 1f, 1f); // Inverse la direction du projectile si le joueur regarde vers la gauche
            }
            // Permet d'ignorer la collision entre le projectile et le joueur
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D projectileCollider = projectile.GetComponent<Collider2D>();

            Physics2D.IgnoreCollision(playerCollider, projectileCollider);
            Destroy(projectile,maxDistance / projectileSpeed);
        }

        /*  if (Input.GetKeyDown(KeyCode.F))
          {
              var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
              projectile.GetComponent<Rigidbody2D>().linearVelocity = projectileSpawnPoint.position  * projectileSpeed;
          }*/


    }
}
