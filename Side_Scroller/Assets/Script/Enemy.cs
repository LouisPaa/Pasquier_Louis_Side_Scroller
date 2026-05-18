
using UnityEngine;
using System.Collections;



public class Enemy : MonoBehaviour
{
    [SerializeField] private float knockbackDuration = 0.5f;
    

    public void ApplyKnockback(Vector2 direction, float distance) //Appelle cette méthodde pour appliquer un recul de l'ennemi
    {
        StopAllCoroutines();
        StartCoroutine(KnockbackRoutine(direction, distance));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction, float distance) // Gère lee recul de l'ennemi
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + direction.normalized * distance;

        float elapsed = 0f;

        while (elapsed < knockbackDuration) 
        {

            float t = elapsed / knockbackDuration;

            transform.position = Vector2.Lerp(startPos, targetPos, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}
