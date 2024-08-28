using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform target; // Assign the player's transform here

    void Update()
    {
        if (target != null)
        {
            // Move towards the player
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Make the enemy face the player
            Vector3 difference = target.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example: Destroy enemy on collision with player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
