using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharaSpell : MonoBehaviour
{
    [Header("dépalcement")]
    [SerializeField] float Speed = 2f;
    [SerializeField] float MaxDistance = 5f;

    [SerializeField] GameObject cubePrefab; 

    Vector2 direction = new Vector2(1, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }
    }
}
