using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCharacterController : MonoBehaviour
{
    // Move speed max
    [SerializeField] protected float moveSpeedMax;

    // My collision list
    [SerializeField] protected string[] collisionTags;

    // Borders
    protected float xBorder = 9f;
    protected float yBorder = 5f;

    // Rigidbody2D
    protected Rigidbody2D rb;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        
    }

    protected virtual void Initialize()
    {
        // My children will override this... maybe
        
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();
    }

    protected void BaseMovementUpdate()
    {
        WarpAround();
        LimitVelocity(rb);
    }

    protected bool CheckCollisionObjectTags(Collider2D collision)
    {
        for (int i = 0; i < collisionTags.Length; i++)
        {
            string tag = collisionTags[i];
            bool collided = (collision.gameObject.tag == tag);

            if (collided)
            {
                return true;
            }
        }

        return false;
    }

    protected void WarpAround()
    {
        // Check X border
        if (transform.position.x > xBorder)
        {
            transform.position = new Vector2(-xBorder, transform.position.y);
        }
        else if (transform.position.x < -xBorder)
        {
            transform.position = new Vector2(xBorder, transform.position.y);
        }

        // Check Y border
        if (transform.position.y > yBorder)
        {
            transform.position = new Vector2(transform.position.x, -yBorder);
        }
        else if (transform.position.y < -yBorder)
        {
            transform.position = new Vector2(transform.position.x, yBorder);
        }
    }

    protected void LimitVelocity(Rigidbody2D rb)
    {
        // Limit my magnitude
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeedMax);
    }
}
