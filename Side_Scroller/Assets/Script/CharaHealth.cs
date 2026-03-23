using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharaHealth : MonoBehaviour
{
    Renderer rend;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private Color originalColor;


    public float _maxHealth = 25f;
   // [SerializeField] private GameObject deathEffect, hitEffect;
    public float _currentHealth;

    [SerializeField] private HealthBar _healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        _currentHealth = _maxHealth;
    }


    private void OnCollisionStay2D(Collision2D collision) // Fait baisser les pv du joueur jusqu'à le tuer 
    {
        if (collision.gameObject.CompareTag("Ennemi") && !collision.gameObject.GetComponent<EnemyStats>().bAttack) 
        {
            collision.gameObject.GetComponent<EnemyStats>().AttackPlayer(); // attaque le joueur en récupérant les stats de l'ennemi
            TakeDammage();
        }

    }
    public void TakeDammage()
    {
        _currentHealth--;
        _healthbar.setSlider(); // récupère le slider de la barre de vie et le lie aux PV du joueur

        // N'EST JAMAIS APPELE
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DoFlash() // Permet de créer un flash de couleur quand l'ennemi prend des dégats 
    {
        rend.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }

    public void Flash() // Gère les variation de couleurs dû au flash 
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }
}
