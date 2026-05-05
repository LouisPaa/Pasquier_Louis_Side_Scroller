using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;

    bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(0, 5, 0);
        } 
        
    }
}
