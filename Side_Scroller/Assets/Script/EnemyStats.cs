using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float dammage = 5f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float health  = 15f;


    // FLASH
    Renderer rend;
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    // Update is called once per frame

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButton("Fire1"))
        {
            Flash();
            health--;
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private IEnumerator DoFlash()
    {
        rend.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }
    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }
}
