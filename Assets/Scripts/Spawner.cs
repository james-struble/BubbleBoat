using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//reference video
//https://www.youtube.com/watch?v=cecD66fZ_4c
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime = 1.0f;

    [SerializeField]
    private float _maximumSpawnTime = 5.0f;

    private float _timeUntilSpawn = 0.0f;

    [SerializeField] GameManager gameManager;

    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Start()
    {
        gameManager.OnStateChanged += GameManager_OnStateChanged;
    }

    void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (gameManager.IsGameOver())
        {
            gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if(_timeUntilSpawn <= 0.0f && !gameOver){
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn(){
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
