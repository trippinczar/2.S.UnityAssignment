using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        // Scenes can be loaded by name or index number
        // This code loads the scene by Scene name
        string levelName = "Level " + levelId; // Level id used as parameter to create full name
        SceneManager.LoadScene(levelName);
    }
}
