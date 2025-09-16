using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : SpaceCharacterController
{
    void Start()
    {
        Initialize();       
    }

    protected override void Initialize()
    {
        // Copying and pasting my parent's Initialize code
        base.Initialize();

        // Set my movement
        rb.velocity = transform.up * moveSpeedMax;
    }

    void FixedUpdate()
    {
        BaseMovementUpdate();
    }
}
