using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{
    public void UnloadControlsCanvas() {
        // play sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        this.transform.parent.gameObject.SetActive(false);
    }
}
