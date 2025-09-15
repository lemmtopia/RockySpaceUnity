using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Max speed
    [SerializeField] private float moveSpeedMax = 3f;

    // Rotation speed
    [SerializeField] private float rotationSpeed = 60f;

    // Forward Force
    [SerializeField] private float moveForce = 1f;

    // Deceleration
    [SerializeField] private float moveDeceleration = 10f;

    // Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveForward();
        RotateSideways();
        LimitSpeed();
    }

    private void MoveForward()
    {
        // Move forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * moveForce);
        }
        else
        {
            // Decelerate
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, moveDeceleration * Time.deltaTime);
        }
    }

    private void RotateSideways()
    {
        // Rotate
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * -1 * Time.deltaTime);
        }
    }

    private void LimitSpeed()
    {
        // Limit my magnitude
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeedMax);
    }
}
