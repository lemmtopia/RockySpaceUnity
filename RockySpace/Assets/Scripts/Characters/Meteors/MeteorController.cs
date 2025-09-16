using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : SpaceCharacterController
{
    // My collision list
    [SerializeField] private string[] collisionTags;

    // Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();

        // Start moving in a random direction
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction * moveSpeedMax;
    }

    void FixedUpdate()
    {
        BaseMovementUpdate(rb);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckCollisionObjectTag(collision, collisionTags))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
