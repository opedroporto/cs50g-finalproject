using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMenu() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        
        SceneManager.LoadScene("StartMenu");
    }
    
    public void ExitGame() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
