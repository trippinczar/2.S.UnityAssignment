using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DoNotTouch")
        {
            LoseScreen();
        }
    }

    public void LoseScreen()
    {
        Debug.Log("Player has died!");

        // Show the lose screen
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }

        // Pause the game
        Time.timeScale = 0f;
    }

    // Method to handle the player winning (optional)
    public void WinScreen()
    {
        Debug.Log("Player has won!");

        // Show the win screen
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }

        // Pause the game
        Time.timeScale = 0f;
    }

    // Method to replay the level
    public void RestartLevel()
    {
        // Reset time scale to normal
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit(); // Quits the game
        Debug.Log("Quited Game");
    }
}
