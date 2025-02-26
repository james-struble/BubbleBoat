using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    
    private int score = 0;

    private int health = 1;

    enum State
    {
        Level1,
        GameOver
    }
    State state;

    [SerializeField] BoatMovement boat;
    [SerializeField] ParticleCollision particleCollision;
    public EventHandler OnStateChanged;
    public EventHandler OnScoreChanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        state = State.Level1;
    }

    void Start()
    {
        boat.OnTakeDamage += BoatMovement_OnTakeDamage;
        particleCollision.OnEnemyHit += ParticleCollision_OnEnemyHit;
    }

    void BoatMovement_OnTakeDamage(object sender, EventArgs e)
    {
        Debug.Log("OWIE");
        health--;
        if (health <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                Destroy(enemy, 4.0f);
            }
            state = State.GameOver;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
            Debug.Log("GAMEOVER");
        }
    }

    void ParticleCollision_OnEnemyHit(object sender, EventArgs e)
    {
        score++;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public bool IsLevelOne()
    {
        return state == State.Level1;
    }

    public int GetScore()
    {
        return score;
    }
}
