using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackSpeed = 1f;      // Attacks per second
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;   // How long the bullet exists
    public GameObject attackPrefab;
    
    private float attackTimer = 0f;
    private Transform enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = 0f;
    }

    // Auto attack mechanic using a timer
    void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 1f / attackSpeed)
        {
            Fire();
            attackTimer = 0f;
        }
    }

    // Fires a bullet toward the closest enemy
    void Fire()
    {
        Transform closestEnemy = GetClosestEnemy();
        if (closestEnemy == null)
        {
            Debug.Log("No enemies found");
            return;
        }

        // Calculate a normalized direction from this object to the enemy
        Vector3 attackDirection = (closestEnemy.position - transform.position).normalized;

        GameObject bullet = Instantiate(attackPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = attackDirection * bulletSpeed;
        }

        Debug.DrawRay(transform.position, attackDirection * 5f, Color.red, 1f);

        // Destroy the bullet after bulletLifetime seconds
        Destroy(bullet, bulletLifetime);
    }

    // Finds and returns the transform of the closest enemy object
    Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy.transform;
            }
        }
        return closest;
    }
}
