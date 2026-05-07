
using UnityEngine;
using System.Collections;



public class Enemy : MonoBehaviour
{
    [SerializeField] private float knockbackDuration = 0.5f;
    

    public void ApplyKnockback(Vector2 direction, float distance)
    {
        StopAllCoroutines();
        StartCoroutine(KnockbackRoutine(direction, distance));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction, float distance)
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
