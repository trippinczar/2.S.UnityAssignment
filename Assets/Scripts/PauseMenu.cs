using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    // Reference to pause menu
    public GameObject pauseMenu;
    // Looks if game is currently paused
    public bool isPaused;
    
    // Reference to PlayerControls class
    private PlayerControls playerControls;

    private void Awake()
    {
        // Initialize PlayerControls
        playerControls = new PlayerControls();
        
        // Register callback for pause action performed
        playerControls.UI.Pause.performed += context => TogglePause();
    }

    private void OnEnable()
    {
        // Enable the Input Action Map
        playerControls.UI.Enable();
    }

    private void OnDisable()
    {
        // Disable the Input Action Map
        playerControls.UI.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Pause menu is disabled by start of the game
        pauseMenu.SetActive(false);
    }

    // toggle pause function
    private void TogglePause()
    {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
    }
    
    // Pause Game function
    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Activates the pause menu
        Time.timeScale = 0f; // Stops animation and gameplay (stops time) -> pause
        isPaused = true; // sets game to being paused
    }
    
    // Resume Game function
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Deactivates pause menu when resuming game
        Time.timeScale = 1f; // Resumes animation and time
        isPaused = false; // sets the game to unpause
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
