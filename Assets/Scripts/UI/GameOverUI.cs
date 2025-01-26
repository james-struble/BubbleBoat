using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameManager gameManager; // Reference to GameManger script for event listening, state checking, and function calling
    //[SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    //[SerializeField] private TextMeshProUGUI hiScoreText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button exitButton;

    void Awake()
    {
        // TextMeshPro method of tracking if button has been pressed
        retryButton.onClick.AddListener(ResetGame); // Calls ResetGame function if button pressed
        exitButton.onClick.AddListener(ExitGame);
    }

    void Start()
    {
        Hide(); // Hide all Game Over UI elements
        gameManager.OnStateChanged += GameManager_OnStateChanged; // Set up event listener for OnStateChanged, will call GameManager_OnStateChanged function when event fires
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (gameManager.IsGameOver()) // Check if game has ended
        {
            Show(); // Show all Game Over UI elements
            scoreText.text = gameManager.GetScore().ToString(); // Change scoreText to score of current game
            //hiScoreText.text = gameManager.GetHighScore().ToString(); // Change hiScoreText to Highscore saved in PlayerPrefs
        }

        // if (gameManager.IsGameWon())
        // {  
        //     Show(); // Show all Game Over UI elements
        //     gameOverText.text = "YOU WIN";
        //     scoreText.text = gameManager.GetScore().ToString(); // Change scoreText to score of current game
        //     hiScoreText.text = gameManager.GetHighScore().ToString(); // Change hiScoreText to Highscore saved in PlayerPrefs
        // }
    }
    
    private void Show() 
    {
        gameObject.SetActive(true); // Show Game Over UI Elements
    }

    private void Hide()
    {
        gameObject.SetActive(false); // Hide Game Over UI Elements
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reset game scene
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
