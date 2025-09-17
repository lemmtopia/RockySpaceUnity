using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeteorController : SpaceCharacterController
{
    // Mini meteors
    [SerializeField] private GameObject meteorSmall;
    [SerializeField] private int meteorsToSpawnAmount;

    private float graceTime = 0.1f;
    private Vector2 motion = Vector2.zero;

    private bool isBigMeteor;

    void Start()
    {
        Initialize();

        rb.velocity = motion;
    }

    protected override void Initialize()
    {
        // Copying and pasting my parent's Initialize code
        base.Initialize();

        // See if I'm a big meteors based on if I need to spawn little ones
        isBigMeteor = (meteorsToSpawnAmount > 0);

        if (isBigMeteor)
        {
            // Start moving in a random direction if I'm a big meteor
            Vector2 direction = MakeRandomDirection();
            SetMotion(direction);
        }
    }

    void FixedUpdate()
    {
        BaseMovementUpdate();
    }

    private void Update()
    {
        graceTime -= Time.deltaTime;
    }

    private void SetGraceTime(float time)
    {
        graceTime = time;
    }

    private void SetMotion(Vector2 direction)
    {
        motion = direction * moveSpeedMax;
    }

    private void SpawnSmallMeteors(int amount)
    {
        float angle = Random.Range(0, 2 * Mathf.PI);

        for (int i = 1; i <= amount; i++)
        {
            angle += (2 * Mathf.PI) / amount;

            SpawnSingleSmallMeteor(angle);
        }
    }

    private void SpawnSingleSmallMeteor(float angle)
    {
        // Create new meteor object
        GameObject newMeteor = Instantiate(meteorSmall, transform.position, Quaternion.identity);
        MeteorController newMeteorComponent = newMeteor.GetComponent<MeteorController>();  // Getting the new object's script
        newMeteorComponent.SetGraceTime(0.1f); // Grace time

        // Set motion
        Vector2 newMeteorMotion = MakeDirectionFromAngle(angle);
        newMeteorComponent.SetMotion(newMeteorMotion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (graceTime <= 0 && CheckCollisionObjectTags(collision))
        {
            SpawnSmallMeteors(meteorsToSpawnAmount);

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
