using UnityEngine;

public class RocketBarrage : MonoBehaviour
{
    public GameObject rocketPrefab;

    public int rocketCount = 4;

    public float fireInterval = 3f;

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            FireBarrage();
            fireTimer = 0f;
        }
    }

    void FireBarrage()
    {
        float angleStep = 360f / rocketCount;

        // First rocket is placed halfway between two standard directions.
        float angleOffset = angleStep / 2f;

        for (int i = 0; i < rocketCount; i++)
        {
            // Calculate rocket angle
            float angle = angleStep * i + angleOffset;

            float radians = angle * Mathf.Deg2Rad;

            float x = Mathf.Cos(radians);
            float y = Mathf.Sin(radians);

            Vector2 direction = new Vector2(x, y);

            // Spawn rocket at player's current position.
            GameObject rocket = Instantiate(
                rocketPrefab,
                transform.position,
                Quaternion.identity
            );

            // Give the rocket direction
            Rocket rocketScript = rocket.GetComponent<Rocket>();

            rocketScript.SetDirection(direction);
        }
    }

    public void IncreaseRocketCount()
    {
        rocketCount = Mathf.Min(rocketCount + 1, 8);
    }
}