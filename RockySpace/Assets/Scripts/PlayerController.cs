using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody2D
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
