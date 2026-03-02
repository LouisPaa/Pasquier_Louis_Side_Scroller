using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    public Vector3 offset = new Vector3(0f, 0f,-1);

    public float distance = 5f;

    Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        GetComponent<Camera>().orthographicSize = distance;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
    }
}
