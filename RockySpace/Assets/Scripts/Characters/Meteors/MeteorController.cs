using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : SpaceCharacterController
{
    // My collision list
    [SerializeField] private string[] collisionTags;

    // Mini meteors
    [SerializeField] private GameObject meteorSmall;

    private float graceTime = 0.1f;

    void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        // Copying and pasting my parent's Initialize code
        base.Initialize();

        // Start moving in a random direction
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction * moveSpeedMax;
    }

    void FixedUpdate()
    {
        BaseMovementUpdate(rb);
    }

    private void Update()
    {
        graceTime -= Time.deltaTime;
    }

    private void SetGraceTime(float time)
    {
        graceTime = time;
    }

    private void SpawnSmallMeteors()
    {
        GameObject smallA = Instantiate(meteorSmall, transform.position + (0.5f * transform.up), Quaternion.identity);
        smallA.GetComponent<MeteorController>().SetGraceTime(0.1f);
        GameObject smallB = Instantiate(meteorSmall, transform.position + (-0.5f * transform.up), Quaternion.identity);
        smallB.GetComponent<MeteorController>().SetGraceTime(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (graceTime <= 0)
        {
            if (CheckCollisionObjectTag(collision, collisionTags))
            {
                if (meteorSmall != null)
                {
                    SpawnSmallMeteors();
                }

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
