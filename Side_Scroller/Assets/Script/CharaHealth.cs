using UnityEngine;

public class CharaHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 25f;
   // [SerializeField] private GameObject deathEffect, hitEffect;
    public float _currentHealth;

    [SerializeField] private HealthBar _healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi")) 
        {
            _currentHealth--;
        }

    }
    public void TakeDammage()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
