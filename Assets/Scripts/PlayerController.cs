using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{

    public bool canMove = true;
    public bool canJump = true;
    public float velocity = 1;
    


    // Update is called once per frame
    void Update()
    {
        if (canMove) MovementUpdate();
    }

    void MovementUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         transform.position += new Vector3(horizontalInput * velocity * Time.deltaTime, verticalInput * velocity * Time.deltaTime, 0);
        
        if (horizontalInput < 0f) {
            transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
        }

        if(horizontalInput > 0f) {
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
        }
    }

}

