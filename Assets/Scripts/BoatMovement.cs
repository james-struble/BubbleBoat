using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed; // Max speed boat is able to go
    [SerializeField] float rotationSpeed; // Speed steering input travels in
    [SerializeField] float drag; // Rate at which boat slows down when not recieving input
    [SerializeField] float moveSpeed = 50; // Speed boat moves at
    [SerializeField] float driftSpeed = 50; // Speed at which boat "catches up" to steering input

    Rigidbody2D rb;
    bool gameOver = false; // Controls whether game has ended
    bool movementInput = false;

    public event EventHandler OnTakeDamage; // Event for when boat is hit
    public event EventHandler OnPauseInput; // Event for when player hits pause input
    [SerializeField] GameObject boatSprite;
    [SerializeField] Transform rudder; // Transform that controllers steering
    [SerializeField] GameManager gameManager; // Take in GameManager for event signals
    [SerializeField] Animator animator;

    void Start()
    {
        gameManager.OnStateChanged += GameManager_OnStateChanged; // Subscribe to OnStateChanged event
        rb = gameObject.GetComponent<Rigidbody2D>(); // Assign rb to gameObjecs rigidbody
        //rudder = gameObject.transform.GetChild(0);
    }

    void GameManager_OnStateChanged(object sender, EventArgs e) // When game state changes in game manager
    {
        if (gameManager.IsGameOver()) // Check if game has ended
        {
            boatSprite.SetActive(false); // Hide boat
            gameOver = true; // Set game to game over
        }
    }

    void Update()
    {
        if (Input.GetKey("space") && !gameOver) // If player performs movement input and game has not ended
        {
            animator.SetBool("isMoving", true);
            rb.AddForce(-rudder.up * moveSpeed);
            float steeringInput = Input.GetAxisRaw("Horizontal"); // Check for steering input 
            rudder.Rotate(0, 0, Mathf.Lerp(rudder.rotation.z, -steeringInput * rotationSpeed, driftSpeed) * Time.deltaTime); // Rotate rudder from current position to position player has input, at a rate of driftspeed
            //boatSprite.transform.Rotate(0, 0, -rudder.rotation.z); // Rotate boat sprite to match direction it is moving
            //movementInput = true;
        } else
        {
            animator.SetBool("isMoving", false);
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, drag  * Time.deltaTime);
            //movementInput = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            OnPauseInput?.Invoke(this, EventArgs.Empty); // Fire OnPauseInput event
        }
    }

    // //https://discussions.unity.com/t/limiting-rigidbody-speed/44191
    void FixedUpdate()
    {
        if(rb.linearVelocity.magnitude > maxSpeed) // If velocity goes above maxSpeed
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed; // Clamp velocity at maxSpeed
        }

        // Tried to properly put physics code here in FixedUpdate but completely messed up the movement so I put it back in Update
        // if (movementInput)
        // {
        //     rb.AddForce(-rudder.up * moveSpeed); // Add force in reverse direction of rudder
        // }
        // else
        // {
        //     rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, drag  * Time.deltaTime); // If player is not performing movement input, slowly move velocity from current velocity to (0,0,0) velocity at a rate of drag
        // }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy")) // On collision with enemy
        {
            OnTakeDamage?.Invoke(this, EventArgs.Empty); // Fire OnTakeDamage event
        }
    }
}
