using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float dammage = 5f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float health  = 15f;

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& Input.GetButtonDown("Fire 1"))
        {
            health--;
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
