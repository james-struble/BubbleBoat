using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameManager gameManager; // Reference to GameManger script for event listening, state checking, and function calling
    [SerializeField] BoatMovement boatMovement;
    //[SerializeField] private TextMeshProUGUI gameOverText;
    //[SerializeField] private TextMeshProUGUI scoreText;
    //[SerializeField] private TextMeshProUGUI hiScoreText;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button exitButton;
    private bool gamePaused = false;

    void Awake()
    {
        resumeButton.onClick.AddListener(ResumeGame); // Calls ResumeGame function if button pressed
        retryButton.onClick.AddListener(ResetGame); // Calls ResetGame function if button pressed
        exitButton.onClick.AddListener(ExitGame); // Calls ExitGame function if button pressed
    }

    void Start()
    {
        Hide(); // Hide all Game Over UI elements
        boatMovement.OnPauseInput += boatMovement_OnPauseInput; // Subscribe to OnPauseInput event
    }

    void boatMovement_OnPauseInput(object sender, EventArgs e)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame(); // Resume game if already paused
            }
            else
            {
                PauseGame(); // Pause game
            }
        }
    }
    
    private void Show() 
    {
        gameObject.SetActive(true); // Show Pause UI Elements
    }

    private void Hide()
    {
        gameObject.SetActive(false); // Hide Pause UI Elements
    }

    private void ResumeGame()
    {
        Hide();
        Time.timeScale = 1f; // Set timeScale to normal 
        gamePaused = false; // Set game state to unpaused

    }

    private void PauseGame()
    {
        Show();
        Time.timeScale = 0f; // Freeze time (this is bad practice but im tired)
        gamePaused = true; // Set game state to paused
    }

    private void ResetGame()
    {
        ResumeGame(); // Resume game so that time unfreezes before resetting scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reset game scene
    }

    private void ExitGame()
    {
        ResumeGame(); // Resume game so that time unfreezes before loading main menu
        SceneManager.LoadScene("MainMenu");
    }
}
