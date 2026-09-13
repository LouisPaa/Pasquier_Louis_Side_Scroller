using UnityEngine;

public class ParallaxLayerSettings : MonoBehaviour
{
    [Header("Parallax")]

    [Tooltip("Facteur Horizontal (0= follow camera | 1 = static)")]
    [Range(0f, 1f)]
    public float speedX = 0.5f;

    [Tooltip("Facteur Vertical (0= follow camera | 1 = static)")]
    [Range(0f, 1f)]
    public float speedY = 0.2f;

    /*[Header("Limites du décor")]

    [Tooltip("Distance maximale de déplacement horizontal")]
    public float maxDistanceX = 10f;

    [Tooltip("Distance maximale de déplacement vertical")]
    public float maxDistanceY = 5f;*/
}
