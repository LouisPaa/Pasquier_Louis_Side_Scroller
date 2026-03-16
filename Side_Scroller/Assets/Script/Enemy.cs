using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public int Damage = 10;
    public CharaHealth CharaHealth;

    Vector2 direction = new Vector2(-2, 0);
    [Header("References")]
    [SerializeField] private Transform playerTransform; 

    [Header("Layers")]
    [SerializeField] private LayerMask playerLayerMask;

    [Header("Detection Ranges")]
    [SerializeField] private float visionRange = 5f;
    [SerializeField] private float engagementRange = 2f;

    [Header("Patrol Settings")]
    [SerializeField] private float patrolRadius = 5f;
    private Vector2 currentPatrolPoint;
    private bool hasPatrolPoint;

    [Header("Combat Settings")]
    [SerializeField] private float attackCooldown = 2f;
    private bool isOnAttackCooldown;
    [SerializeField] private float attackRange = 1f;

    private bool isPlayerVisible;
    private bool isPlayerInRange;
    public void TakeDammage(int damage) // Détruit l'ennemi lorsque sa vie est à 0 ou moins
    {
        HP -= damage;
        if ( HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Trouve la position du joueur
        }
    }

    private void Update()
    {
        DetectPlayer();
        UpdateBehaviourState();
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, engagementRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

    private void DetectPlayer()
    {
        isPlayerVisible = Physics.CheckSphere(transform.position, visionRange, playerLayerMask); // Définit si le joueur est dans le champs de vison de l'ennemi
        isPlayerInRange = Physics.CheckSphere(transform.position, engagementRange, playerLayerMask); // définit si le joueur est dans le champs d'attaque de l'ennemi
    }

    private void FindPatrolpoint() // Définit la zone de patrouille de l'ennemi 
    {
        float randomX = Random.Range(-patrolRadius, patrolRadius);
        float randomy = Random.Range(-patrolRadius, patrolRadius);

        Vector2 potentialPoint = new Vector2(transform.position.x + randomX, transform.position.y + randomy);

        if (Physics.Raycast(potentialPoint, -Vector2.up, 1f, playerLayerMask)) // Vérifie que le point de patrouille est sur le sol
        {
            currentPatrolPoint = potentialPoint;
            hasPatrolPoint = true;
        }
    }

    private void PerformPatrol() // Permet à l'ennemi de patrouiller dans une zone définie
    {
        if (!hasPatrolPoint)
            FindPatrolpoint();

        if (hasPatrolPoint)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint, Time.deltaTime * 2f);
            if (Vector2.Distance(transform.position, currentPatrolPoint) < 1f)
                hasPatrolPoint = false;
        }
    }

    private void PerformChase() // Permet à l'ennemi de poursuivre le joueur lorsqu'il est dans son champs de vision
    {
        if (playerTransform != null)
        {
           transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * 3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && !isOnAttackCooldown)
        {
            if(collision.gameObject.tag == "Player")
            {
                //CharaHealth.TakeDammage(Damage);
            }
        }
        
    }

    private void UpdateBehaviourState()
    {
        if (! isPlayerVisible && isPlayerInRange)
        {
            PerformPatrol();
        }
        else if (isPlayerVisible && !isPlayerInRange)
        {
            PerformChase();
        }
    }
}
