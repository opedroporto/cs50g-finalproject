using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMenuLevels : MonoBehaviour
{
    public int levelsQuantity;
    public GameObject LevelButton;
    // Start is called before the first frame update
    void Start()
    {   
        // play menu theme song
        FindObjectOfType<AudioManager>().Play("MenuTheme");

        GameInfo gameInfo = GameObject.FindObjectOfType<GameInfo>();

        for (int i = 2; i < levelsQuantity + 1; i++) {
            GameObject button = Instantiate(LevelButton, transform);
            button.GetComponentInChildren<Text>().text = i.ToString();
            // locked levels
            if (i > (gameInfo.unlockedLevels)) {
                button.GetComponentInChildren<Button>().interactable = false;
            }
        }
    }
}
