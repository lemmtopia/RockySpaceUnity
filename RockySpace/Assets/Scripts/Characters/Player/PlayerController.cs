using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceCharacterController
{
    // My collision list
    [SerializeField] private string[] collisionTags;

    // Rotation speed
    [SerializeField] private float rotationSpeed = 60f;

    // Forward Force
    [SerializeField] private float moveForce = 1f;

    // Deceleration
    [SerializeField] private float moveDeceleration = 10f;

    // Am I using mouse or not?
    [SerializeField] private bool isUsingMouse = true;

    // GameController reference
    private GameController game;

    // Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();

        // Getting the game
        game = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        MoveForward();

        if (isUsingMouse)
        {
            LookAtMouse();
        }
        else
        {
            TurnAround();
        }

        BaseMovementUpdate(rb);
    }

    private void MoveForward()
    {
        // Move forward
        KeyCode key = KeyCode.UpArrow;

        if (isUsingMouse)
        {
            key = KeyCode.Space;
        }

        if (Input.GetKey(key))
        {
            rb.AddForce(transform.up * moveForce);
        }
        else
        {
            // Decelerate
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, moveDeceleration * Time.deltaTime);
        }
    }

    private void TurnAround()
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

    private void LookAtMouse()
    {
        // Getting the mouse position in World space (inside the scene)
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Getting the normalized distance (direction) of me vs. mouse
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Rotate
        transform.up = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckCollisionObjectTag(collision, collisionTags))
        {
            // Restart
            game.RestartGame();
        }
    }
}
