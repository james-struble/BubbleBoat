using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float drag;
    //[SerializeField] float SteerAngle;
    //[SerializeField] float Traction;
    //Vector3 MoveForce;
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float driftSpeed = 50;

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
            rb.AddForce(-transform.up * moveSpeed);
            float boatRotation = Input.GetAxisRaw("Horizontal");
            transform.Rotate(0, 0, Mathf.Lerp(transform.rotation.z, -boatRotation * rotationSpeed, driftSpeed) * Time.deltaTime);
        } else
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, drag  * Time.deltaTime);
            Debug.Log(rb.linearVelocityX + " " + rb.linearVelocityY);
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
}
