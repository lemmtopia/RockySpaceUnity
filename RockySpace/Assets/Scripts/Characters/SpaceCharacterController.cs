using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCharacterController : MonoBehaviour
{
    // Move speed max
    [SerializeField] protected float moveSpeedMax;

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
        // My children will override this...
        
        // Getting my rb
        rb = GetComponent<Rigidbody2D>();
    }

    protected void BaseMovementUpdate(Rigidbody2D rb)
    {
        WarpAround();
        LimitVelocity(rb);
    }

    protected bool CheckCollisionObjectTag(Collider2D collision, string[] tags)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            string tag = tags[i];
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
        // X
        if (transform.position.x > xBorder)
        {
            transform.position = new Vector2(-xBorder, transform.position.y);
        }
        else if (transform.position.x < -xBorder)
        {
            transform.position = new Vector2(xBorder, transform.position.y);
        }

        // Y
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
