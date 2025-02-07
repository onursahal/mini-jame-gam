using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public bool canMove = true;
    public bool canJump = true;
    public float velocity = 1;


    // Update is called once per frame
    void Update()
    {
        if (canMove) MovimentUpdate();

    }

    void MovimentUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += 5 * Time.deltaTime * velocity * Vector3.left;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += 5 * Time.deltaTime * velocity * Vector3.right;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if ((Input.GetKey(KeyCode.Space) & canJump) || (Input.GetKey(KeyCode.W) & canJump))
        {
            canJump = false;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 6);
        }
        // Contoller definitions
        if (Input.GetButton("Jump") && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, 6);
        }
        transform.position += 5 * Time.deltaTime * velocity * Vector3.right * Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

}

