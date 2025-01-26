using System;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource gameMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.OnStateChanged += GameManager_OnStateChanged;
    }

    void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (gameManager.IsGameOver())
        {
            gameMusic.Pause();
            gameOver.Play();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
