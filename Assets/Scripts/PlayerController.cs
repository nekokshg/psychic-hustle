using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isMoving;
    private Rigidbody2D rb;
    private Vector2 movement; //Stores x and y


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() //<= make into handleupdate later
    {
        //Update movement input
        movement.x = Input.GetAxisRaw("Horizontal"); //Will return a value between -1 (left), 1 (right), 0 (no input)
        movement.y = Input.GetAxisRaw("Vertical");

        //Remove diagonal movement
        if (movement.x != 0) movement.y = 0;

        //Update animator movement parameters


        //Handle idle direction


    }

    private void FixedUpdate() //Similar to Update() except executed on a fixed timer
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Move the rigid body and make sure it collides with anything on the way
    }


}
