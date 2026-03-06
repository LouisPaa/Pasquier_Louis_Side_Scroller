using UnityEngine;

public class CharaHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 25f;
    [SerializeField] private GameObject deathEffect, hitEffect;
    private float _currentHealth;

    [SerializeField] private HealthBar _healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDammage(int amount)
    {
        _currentHealth -= amount;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
