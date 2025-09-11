using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{
   
    [Header("KeyBinds")]
    public KeyCode dashKey; // The dash key can be set in the editor 

    [Header("Stats")] // These stats are changable in the editor for testing purposes, and we can determine these values with character attributes later
    public float movementSpeed;
    public float dashCooldown = 2f;
    public float dashDistance = 5f;
    public float dashSpeed = 50f;

// All these are private variables for this script's logic
    private float nextFireTime = 0f;

    private Vector2 movement;

    private float verticalInput;
    private float horizontalInput;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private bool isDashing;
    
    private void Start()
    {
        isDashing = false;
    }
    private void Update()
    {
        // Every frame, the sript checks if the player is dashing. If so, it moves the player (very rapidly) in the direction that the 
        //player was moving when they clicked the dash key, if not, it reads the input every frame to get movement inputs
        if (isDashing)
        {
            Dash();
        }
        else
        {
            TrackPlayerInputs();
        }
            
    }
    // FixedUpdate must be called for certain things that need to be seperated from the player's frame rate
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void TrackPlayerInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Tracks "A" and "D" key
        verticalInput = Input.GetAxisRaw("Vertical"); // Tracks "W" and "S" key

        if (Input.GetKeyDown(dashKey) && Time.time >= nextFireTime) //Checks if the player clicked the dash key, and if their dash cooldown is ready
        {
            SetDashing(); 
            nextFireTime = Time.time + dashCooldown; //Reset the cooldown to dash again
        }

    }
    private void MovePlayer()
    {
        movement = new Vector2(horizontalInput, verticalInput).normalized * movementSpeed * Time.deltaTime; //"Normalized' is to ensure that diagonal movements are not faster than other movements
        transform.position = (Vector2)transform.position + movement;

    }
    private void SetDashing()
    {
        Vector2 dashDirection = new Vector2(horizontalInput, verticalInput); //Picks a direction to dash based on the last direction the player was moving
        startPosition = transform.position; // Saves the position it is at for the MoveTowards() function
        endPosition = startPosition + (dashDirection * dashDistance); //Choses where the dash will end based on the dashDistance variable (can be changed in the editor if you want to test this)
        isDashing = true; // When this bool is true, the game will move the player every frame towards the end position
        
    }
    private void Dash()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPosition, dashSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, endPosition) < 0.1f) //Checks if the player is close enough to the end position to be considered a complete dash (I did it this way for safety purposes)
        {
            isDashing = false; // Now the game no longer moves the player every frame
            transform.position = endPosition; //Clips the player to the end position incase its slightly off (again for safelty purposes
        }
    }
}

