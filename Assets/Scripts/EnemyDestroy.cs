using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy the enemy
        }
    }
}
