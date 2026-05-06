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

    float lastDirection = 1f;
    float inputX;
    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX != 0)
        {
            lastDirection = inputX;
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(lastDirection* projectileSpeed,0f);


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
