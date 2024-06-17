using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads Level_0
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game
        Debug.Log("Quited Game");
    }
}
