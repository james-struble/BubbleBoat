using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Resources:
//https://www.youtube.com/watch?v=zWy29yeFNX8


[RequireComponent(typeof(Rigidbody2D))]

public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the screen position of object in Pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Get the right side of the screen in world units
        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x;

        float TopOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).y;

        // If player is moving through left side of the screen
        if (screenPos.x <= 0 && rb.linearVelocity.x < 0){
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }

        // If Player is moving through right side of the screen
        else if (screenPos.x >= Screen.width && rb.linearVelocity.x > 0){
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }
        // If Player is moving through top side of the screen
        else if (screenPos.y >= Screen.height && rb.linearVelocity.y > 0){
            transform.position = new Vector2(transform.position.x, bottomOfScreenInWorld);
        }
        // If Player is moving through bottom side of the screen
        else if (screenPos.y <= 0 && rb.linearVelocity.y < 0){
            transform.position = new Vector2(transform.position.x, TopOfScreenInWorld);
        }
    }


}
