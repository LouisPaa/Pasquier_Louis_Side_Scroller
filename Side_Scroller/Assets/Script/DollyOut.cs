using UnityEngine;
using System.Collections;
public class DollyOut : MonoBehaviour
{
    [Header("CameraSettings")]
    [SerializeField] private float zoomOutside = 10f;
    [SerializeField] private float zoomSpeed = 2f;

    private Camera cam;
    private float defaultSize;
    private Coroutine zoomCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        defaultSize = cam.orthographicSize;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            StartZoom(zoomOutSize);
        }
    }

    void StartZoom(float targetSize)
    {
        if (zoomCoroutine != null)
        {
            StopCoroutine(zoomCoroutine);
        }

        zoomCoroutine = StartCoroutine(ZoomCamera(targetSize));
    }

    IEnumerator SmoothZoom(float targetSize) 

    // Update is called once per frame
    void Update()
    {
        
    }
}
