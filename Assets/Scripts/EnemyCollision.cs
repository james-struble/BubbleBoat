using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Resources:
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.CompareTag.html
//https://www.youtube.com/watch?v=EjuTPMQOjLg
//https://discussions.unity.com/t/destroy-multiple-gameobjects-with-tag-c/159371/3
public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    GameManager gameStatus;
    public GameObject Spawners;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
     private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            gameStatus.playerHealth--;
            Destroy(collision.gameObject);
            if(gameStatus.playerHealth <= 0){
                gameStatus.gameOver = true;
                Destroy(gameObject);
                Destroy(Spawners);
            }

        }
        if(gameStatus.gameOver == true){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                Destroy(enemy, 4.0f);
            }
        }
    }
    
}
