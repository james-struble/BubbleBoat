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
        // TextMeshPro method of tracking if button has been pressed
        resumeButton.onClick.AddListener(ResumeGame);
        retryButton.onClick.AddListener(ResetGame); // Calls ResetGame function if button pressed
        exitButton.onClick.AddListener(ExitGame);
    }

    void Start()
    {
        Hide(); // Hide all Game Over UI elements
        boatMovement.OnPauseInput += boatMovement_OnPauseInput; 
    }

    void boatMovement_OnPauseInput(object sender, EventArgs e)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Update()
    {
        Debug.Log("THE END");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("THE END");
            // if (gamePaused)
            // {
            //     ResumeGame();
            // }
            // else
            // {
            //     PauseGame();
            // }
        }
    }
    
    private void Show() 
    {
        gameObject.SetActive(true); // Show Game Over UI Elements
    }

    private void Hide()
    {
        gameObject.SetActive(false); // Hide Game Over UI Elements
    }

    private void ResumeGame()
    {
        Hide();
        Time.timeScale = 1f;
        gamePaused = false;

    }

    private void PauseGame()
    {
        Show();
        Time.timeScale = 0f;
        gamePaused = true;
    }

    private void ResetGame()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reset game scene
    }

    private void ExitGame()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
