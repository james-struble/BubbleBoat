using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float drag;
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float driftSpeed = 50;
    [SerializeField] GameObject boatSprite;

    Rigidbody2D rb;
    Transform propeller;
    bool gameOver = false;

    public event EventHandler OnTakeDamage;
    public event EventHandler OnPauseInput;
    [SerializeField] GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.OnStateChanged += GameManager_OnStateChanged;
        rb = gameObject.GetComponent<Rigidbody2D>();
        propeller = gameObject.transform.GetChild(0);
    }

    void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (gameManager.IsGameOver())
        {
            boatSprite.SetActive(false);
            gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !gameOver)
        {
            rb.AddForce(-propeller.up * moveSpeed);
            float boatRotation = Input.GetAxisRaw("Horizontal");
            propeller.Rotate(0, 0, Mathf.Lerp(propeller.rotation.z, -boatRotation * rotationSpeed, driftSpeed) * Time.deltaTime);
        } else
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, drag  * Time.deltaTime);
            
            //Debug.Log(rb.linearVelocityX + " " + rb.linearVelocityY);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseInput?.Invoke(this, EventArgs.Empty);
        }


        // float boatRotation = Input.GetAxisRaw("Horizontal");
        // transform.Rotate(0, 0, Mathf.Lerp(transform.rotation.z, -boatRotation * rotationSpeed, driftSpeed) * Time.deltaTime);

        // Debug.Log("" + transform.rotation.z + " " + -boatRotation * rotationSpeed);
    }
    
    // public float maxSpeed = 200f;//Replace with your max speed


    // //https://discussions.unity.com/t/limiting-rigidbody-speed/44191
    void FixedUpdate()
    {
        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            OnTakeDamage?.Invoke(this, EventArgs.Empty);
            Debug.Log("OUCH");
        }
    }
}
