using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{
   
    [Header("KeyBinds")]
    public KeyCode dashKey; // The dash key can be set in the editor 

    [Header("Stats")] // These stats are changable in the editor for testing purposes, and we can determine these values with character attributes later
    //public float movementSpeed;
    public float dashCooldown = 2f;
    private int consec_dashes = 0;
    private float prev_dash = 0f;
    public float dashDistance = 3f;
    public float dashSpeed = 15f;
    public float dashTime = 0f;

    public float touchWall = 1f;

// All these are private variables for this script's logic
    private float nextFireTime = 0f;

    private Vector2 movement;

    private float verticalInput;
    private float horizontalInput;

    private Vector2 startPosition;
    private Vector2 endPosition;

    public bool isDashing = false;

    private Vector2 dashDirection;

    /*private void Start()
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
        movement = new Vector2(horizontalInput, verticalInput).normalized * movementSpeed * Time.deltaTime * touchWall; //"Normalized' is to ensure that diagonal movements are not faster than other movements
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
            transform.position = endPosition; //Clips the player to the end position incase its slightly off (again for safelty purposes)
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // made by Jeb
    {
        if (collision.CompareTag("Wall")) // checks if player is touching wall, sets speed to 10% if touching
        {
            touchWall = 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // made by Jeb
    {
        touchWall = 1f; // resets speed to 100% if not touching wall
    }*/

    [SerializeField] private float movementSpeed = 4f;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    public GameObject Character;

    public GameObject door_object; //required for reference to player abilities
    public Door door; //required for reference to player abilities
    void Start() {
        rb = Character.GetComponent<Rigidbody2D>(); // Finds player character's rigidbody object

        door_object = GameObject.FindWithTag("Door"); //required for reference to player abilities
        door = door_object.GetComponent<Door>(); //required for reference to player abilities
    }

    void FixedUpdate() {
        if (isDashing)
        {
            Dash();
        }
        else
        {
            MovePlayer();
        }
            
        
    }

    void Update() {
      
       
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Finds direction to move in using horizontal and vertical axis
       
        if (Input.GetKeyDown(dashKey) && Time.time >= nextFireTime && door.Has_ability("Dash")) { // check for dash
            SetDashing();

            if (door.Has_ability("Light_Speed"))
            {
                if (Time.time - dashCooldown >= prev_dash) consec_dashes = 0;
                consec_dashes += 1;
                if (consec_dashes >= 3)
                {
                    nextFireTime = Time.time + dashCooldown;
                    consec_dashes = 0;
                }
            }
            else
            {
                nextFireTime = Time.time + dashCooldown;
            }
            prev_dash = Time.time;
        }
        
    }
    private void MovePlayer()
    {
        rb.velocity = movementDirection * movementSpeed; // change player velocity
    }
    private void Dash()
    {
        rb.velocity = dashDirection * dashSpeed;
        dashTime -= Time.deltaTime;
        if (Vector2.Distance(transform.position, endPosition) < 0.1f || dashTime <= 0) //Checks if the player is close enough to the end position to be considered a complete dash (I did it this way for safety purposes)
        {
            rb.velocity = new Vector2 (0,0);
            isDashing = false; // Now the game no longer moves the player every frame
            dashTime = 0f;
            //transform.position = endPosition; //Clips the player to the end position incase its slightly off (again for safelty purposes)
        }
    }
    private void SetDashing()
    {
        dashDirection = movementDirection.normalized; //Picks a direction to dash based on the last direction the player was moving
        startPosition = transform.position; // Saves the position it is at for the MoveTowards() function
        endPosition = startPosition + (dashDirection * dashDistance); //Choses where the dash will end based on the dashDistance variable (can be changed in the editor if you want to test this)
        isDashing = true; // When this bool is true, the game will move the player every frame towards the end position
        dashTime = dashDistance/dashSpeed;

    }

    public void EndDash() //ends dash prematurely and bounces back a little bit
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - dashDirection.x, gameObject.transform.position.y - dashDirection.y, 0);
        rb.velocity = new Vector2(0, 0);
        dashTime = 0;
        isDashing = false;
    }

    public void ChangeSpeed(float percentage)
    {
        movementSpeed *= 1 + percentage;
        Debug.Log($"Player speed increased to {movementSpeed}");
    }
}   


