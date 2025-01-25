using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Resources:
//https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.CompareTag.html
//https://www.youtube.com/watch?v=EjuTPMQOjLg
//https://discussions.unity.com/t/destroy-multiple-gameobjects-with-tag-c/159371/3
public class GameManager : MonoBehaviour
{
    public int playerHealth = 3;
    public GameObject Spawners;
    public bool gameOver = false;
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
            playerHealth--;
            Destroy(collision.gameObject);
            if(playerHealth <= 0){
                gameOver = true;
                Destroy(gameObject);
                Destroy(Spawners);
            }

        }
        if(gameOver == true){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                Destroy(enemy, 4.0f);
            }
        }
    }
}
