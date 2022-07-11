using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public void LoadLevel() {
        // stop menu theme song
        FindObjectOfType<AudioManager>().Stop("MenuTheme");

        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // play in play theme song
        FindObjectOfType<AudioManager>().Play("InPlayTheme");

        SceneManager.LoadScene("Level");
    }
    public void GoBackToStartMenu() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        
        SceneManager.LoadScene("StartMenu");
    }
}
