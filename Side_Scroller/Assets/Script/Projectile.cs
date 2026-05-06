using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Projectile : MonoBehaviour
   
{
    

    
    public float knockbackDistance = 10f; // Définis la distance à laquelle l'ennemi sera repoussé
    private void OnCollisionEnter2D(Collision2D collision) // Permet de repousser l'ennemi lorsque le projectile entre en contact avec l'ennemi
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Rigidbody2D EnnemiRb2D = collision.gameObject.GetComponent<Rigidbody2D>();
            if (EnnemiRb2D != null)
            {
                Vector2 direction = (collision.transform.position - transform.position).normalized; // Calcule la direction de l'ennemi lorsqu'il est repoussé par le projectile 
                collision.transform.position += (Vector3)(direction * knockbackDistance); // Applique le déplacement de recul à l'ennemi
            }

            if (collision.gameObject.CompareTag("Ennemi"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Vector2 direction = (collision.transform.position - transform.position).normalized;
                    enemy.ApplyKnockback(direction, 2f);
                }
            }

            Destroy(gameObject); // détruit le projectile après la collision avec l'ennemi
        }
    }
}

