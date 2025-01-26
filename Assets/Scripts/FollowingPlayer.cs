using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

// Reference video
// https://www.youtube.com/watch?v=4Wh22ynlLyk
public class FollowingPlayer : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    
    GameManager gameStatus;
    private Rigidbody2D rb;
    private float rotationSpeed = 2f;
    private Vector2 movement;
    private bool gameOver = false;
    [SerializeField] float gameOverSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        gameStatus = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        gameStatus.OnStateChanged += GameManager_OnStateChanged;
        
    }

    void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (gameStatus.IsGameOver())
        {
            gameOver = true;
            //Debug.Log("GAME OVER");
        }
    }

    void Update()
    {
        if(!gameOver){
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            //Debug.Log("aiming for player");
        }
        if(gameOver){
            //Debug.Log("Game Over");
            Vector3 direction = player.position - transform.position;
            Vector3 oppositeDirection = -direction;
            float angle = Mathf.Atan2(oppositeDirection.y, oppositeDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            oppositeDirection.Normalize();
            movement = oppositeDirection * gameOverSpeed;
        }
    }

    private void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (gameStatus.gameOver == false){
    //         Vector3 direction = player.position - transform.position;
    //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //         rb.rotation = angle;
    //         direction.Normalize();
    //         movement = direction;
    //         //Debug.Log("Game Not Over");
    //     }
    //     if (gameStatus.gameOver == true){
    //         Debug.Log("Game Over");
    //         Vector3 direction = player.position - transform.position;
    //         Vector3 oppositeDirection = -direction;
    //         float angle = Mathf.Atan2(oppositeDirection.y, oppositeDirection.x) * Mathf.Rad2Deg;
    //         rb.rotation = angle;
    //         oppositeDirection.Normalize();
    //         movement = oppositeDirection;
    //     }
        
        
    // }
    // private void FixedUpdate(){
    //     moveCharacter(movement);
    // }
    // void moveCharacter(Vector2 direction){
    //     rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }
//}
