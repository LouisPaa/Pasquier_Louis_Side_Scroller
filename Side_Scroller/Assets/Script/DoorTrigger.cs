using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] int switchesNeeded = 2;

    static int currentSwitches = 0;

    bool activated = false;
    bool isOpened = false;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Projectile"))
        {
            if (!activated)
            {
                currentSwitches++;
                activated = true;
            }

            if (currentSwitches >= switchesNeeded && ! isOpened)
            {
                isOpened = true;
                door.transform.position += new Vector3(0, 5, 0);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player") || col.CompareTag("Projectile"))
            {
                if (activated)
                {
                    currentSwitches--;
                    activated = false;
                }
            }
    }
}
