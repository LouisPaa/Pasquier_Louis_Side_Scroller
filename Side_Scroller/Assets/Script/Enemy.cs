
using UnityEngine;
using System.Collections;



public class Enemy : MonoBehaviour
{
    public float knockbackDuration = 0.5f;
    private float elapsed;

    public void ApplyKnockback(Vector2 direction, float distance)
    {
        StopAllCoroutines();
        StartCoroutine(KnockbackRoutine(direction, distance));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction, float distance)
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + direction.normalized * distance;

        while (elapsed < knockbackDuration)
        {

            float t = 1 - Mathf.Pow(1 - (Time.time / knockbackDuration), 2);

            transform.position = Vector2.Lerp(startPos, targetPos, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}
