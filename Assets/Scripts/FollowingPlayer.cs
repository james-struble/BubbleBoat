using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

// Reference video
// https://www.youtube.com/watch?v=4Wh22ynlLyk
public class FollowingPlayer : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    
    [SerializeField]
    public GameManager gameStatus;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.gameOver == false){
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        if (gameStatus.gameOver == true){
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        
        
    }
    private void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }
}
