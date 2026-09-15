using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Vector2 direction;

    public float speed = 5f;
    public float lifetime = 5f;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;

        // Rotate rocket to face its direction.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}