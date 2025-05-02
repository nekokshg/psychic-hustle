using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask randomEncounterLayer;
    [SerializeField] float encounterCheckInterval;
    private float encounterTimer = 0f;
    private Rigidbody2D rb;
    private Vector2 movement; //Stores x and y
    private CharacterAnimator animator;
    public event Action OnEncountered;

    public bool CanMove { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<CharacterAnimator>();
    }

    public void HandleUpdate()
    {
        //Update movement input
        movement.x = Input.GetAxisRaw("Horizontal"); //Will return a value between -1 (left), 1 (right), 0 (no input)
        movement.y = Input.GetAxisRaw("Vertical");

        //Remove diagonal movement
        if (movement.x != 0) movement.y = 0;

        //Update animator movement parameters
        animator.MoveX = movement.x;
        animator.MoveY = movement.y;
        animator.IsMoving = movement.magnitude > 0; //When you check the magnitude you're measuring how fast it's moving 

        //Update timer and check for encounters periodically
        encounterTimer += Time.deltaTime;
        if (encounterTimer >= encounterCheckInterval)
        {
            CheckForEncounters();
            encounterTimer = 0f;
        }
    }

    private void FixedUpdate() //Similar to Update() except executed on a fixed timer
    {
        if (CanMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Move the rigid body and make sure it collides with anything on the way
        }
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEncounterLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= 10) // 10% chance
            {
                animator.IsMoving= false;
                OnEncountered();
            }
        }
    }


}
