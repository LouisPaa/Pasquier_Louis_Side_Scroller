using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float dammage = 5f;

    [SerializeField] public float attackCooldown = 1f;
    [SerializeField] public float attackCooldownMax = 1f;
    public bool bAttack = false;
    [SerializeField] private float health  = 15f;
    [SerializeField]  private CharaHealth CharaHealth;
    [SerializeField] private CharaHealth playerHealth;
    [SerializeField] private float healAmount = 5f;

    // FLASH
    Renderer rend;
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        attackCooldown = attackCooldownMax;
    }

    // Update is called once per frame
    
    private void OnCollisionStay2D(Collision2D collision) // Permet d'attaquer l'ennemi en cliquant sur clic gauche 
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButton("Fire1"))
        {
            Flash();
            health--;
        }
        
    }

    public void AttackPlayer()
    {
        bAttack = true;
    }

    void Update()
    {
        if (health <= 0)  // détruit le GameObject si l'objet tombe à zéro PV
        {
            playerHealth.Heal(healAmount); // Appelle une fonction qui permet au joueur de récupérer des PV après avoir élimininé un ennemi
            Destroy(gameObject.transform.parent.gameObject);
        }

        if (bAttack) // définis le cooldown de l'attaque 
        {
            attackCooldown -= Time.deltaTime;

            if (attackCooldown <= 0f)
            {
                bAttack = false;
                attackCooldown = attackCooldownMax;
            }
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
