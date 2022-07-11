using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel() {

        GameInfo gameInfo = GameObject.FindObjectOfType<GameInfo>();
        gameInfo.overrideCurrentLevel(int.Parse(GetComponentInChildren<Text>().text));

        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // load scene
        SceneManager.LoadScene("LevelMenu");
    }
}
