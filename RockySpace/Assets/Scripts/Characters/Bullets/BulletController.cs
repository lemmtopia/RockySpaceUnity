using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : SpaceCharacterController
{
    private Rigidbody2D rb;

    void Start()
    {
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();

        // Set my movement
        rb.velocity = transform.up * moveSpeedMax;
    }

    void FixedUpdate()
    {
        BaseMovementUpdate(rb);
    }
}
