using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
      Debug.Log("PlayGame");
      SceneManager.LoadScene(1);
        // Load the next scene (make sure you add a scene in Build Settings)
        
    }

    public void QuitGame()
    {
      Debug.Log("QuitGame");
        // Quit the game (will only work in a built game)
        Application.Quit();
    }
}
