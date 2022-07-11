using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GameInfo gameInfo = GameObject.FindObjectOfType<GameInfo>();
        
        GetComponent<Text>().text = "Level " + gameInfo.currentLevel.ToString();
    }
}
