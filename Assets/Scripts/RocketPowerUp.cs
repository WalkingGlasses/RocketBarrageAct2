using UnityEngine;

public class RocketPowerUp : MonoBehaviour
{
    public float pickupDistance = 0.75f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.transform.position
        );

        if (distance <= pickupDistance)
        {
            RocketBarrage barrage = player.GetComponent<RocketBarrage>();

            if (barrage != null)
            {
                barrage.IncreaseRocketCount();

                Destroy(gameObject);
            }
        }
    }
}