using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null) {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            Vector3 direction = player.position - transform.position;
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }
    }
}
