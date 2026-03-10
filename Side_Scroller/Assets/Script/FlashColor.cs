using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlashColor : MonoBehaviour
{
    public Renderer rend;
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    private Color originalColor;

    private void Start()
    {
        originalColor = rend.material.color;
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

    private void Update()
    {
        if (Input.GetButtonDown("Fire 1"))
        {
            Flash();
        }
    }
}
