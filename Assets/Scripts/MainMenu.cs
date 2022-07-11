using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsCanvas;

    public void LoadControlsCanvas() {
        controlsCanvas.SetActive(true);

        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
    
    public void ExitGame() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
