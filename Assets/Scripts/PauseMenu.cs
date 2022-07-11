using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        // play sound
        FindObjectOfType<AudioManager>().Play("Pause");

        // pause in play theme song
        FindObjectOfType<AudioManager>().Pause("InPlayTheme");

        // pause player and activate cursor
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() {
        // play sound
        FindObjectOfType<AudioManager>().Play("Resume");

        // resume in play theme song
        FindObjectOfType<AudioManager>().UnPause("InPlayTheme");

        // resume player
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // stop in play theme song
        FindObjectOfType<AudioManager>().Stop("InPlayTheme");

        SceneManager.LoadScene("StartMenu");
    }
    
    public void ExitGame() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // stop in play theme song
        FindObjectOfType<AudioManager>().Stop("InPlayTheme");

        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
