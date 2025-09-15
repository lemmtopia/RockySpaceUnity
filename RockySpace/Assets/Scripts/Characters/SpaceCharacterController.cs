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

    void Start()
    {
        
    }

    void Update()
    {
        
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

    protected void LimitSpeed(Rigidbody2D rb)
    {
        // Limit my magnitude
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeedMax);
    }
}
