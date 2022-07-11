using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public int unlockedLevels;
    public int currentLevel;

    public static GameInfo instance;
    void Awake() {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
    }

    public void overrideCurrentLevel(int level) {
        currentLevel = level;
    }
}
