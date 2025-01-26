using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//References:
// https://www.youtube.com/watch?v=DX7HyN7oJjE
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject creditsUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the next scene in the build index
    }

    public void DisplayCredits()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!"); //prints "QUIT!" to the console
        Application.Quit(); //quits the game
    }
}
