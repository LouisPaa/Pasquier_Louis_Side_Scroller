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
    float inputX;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = projectileSpawnPoint.right * projectileSpeed;

            Destroy(projectile,maxDistance / projectileSpeed);
        }

      /*  if (Input.GetKeyDown(KeyCode.F))
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().linearVelocity = projectileSpawnPoint.position  * projectileSpeed;
        }*/
    }
}
