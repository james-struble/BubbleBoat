using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float bubbleBlastSpeed;
    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            rb.AddForce(-transform.up * bubbleBlastSpeed);
        }

        float boatRotation = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -boatRotation * rotationSpeed * Time.deltaTime);
    }
    
    public float maxSpeed = 200f;//Replace with your max speed


    //https://discussions.unity.com/t/limiting-rigidbody-speed/44191
    void FixedUpdate()
    {
        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
