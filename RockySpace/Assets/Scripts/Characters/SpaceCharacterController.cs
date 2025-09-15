using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCharacterController : MonoBehaviour
{
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
}
