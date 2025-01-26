using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] GameManager gameManager; // Reference to GameManger script for event listening, state checking, and function calling
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        //Hide(); // Hide Score UI elements on game start
        gameManager.OnScoreChanged += GameManager_OnScoreChanged; // Set up event listener for OnScoreChanged, will call GameManager_OnScoreChanged function when event fires
        gameManager.OnStateChanged += GameManager_OnStateChanged; // Set up event listener for OnStateChanged, will call GameManager_OnStateChanged function when event fires
    }

    private void GameManager_OnScoreChanged(object sender, EventArgs e)
    {
        scoreText.text = gameManager.GetScore().ToString(); // When score is changed, update scoreText
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(gameManager.IsGameOver()) // When stat is changed, if game hasn't started or has ended
        {
            Hide(); // Hide Score UI elements
        } else 
        {
            Show(); // Show Score UI elements
        }
    }

    private void Show() // Show Score UI elements
    {
        gameObject.SetActive(true);
    }

    private void Hide() // Hide Score UI elements
    {
        gameObject.SetActive(false);
    }
}
