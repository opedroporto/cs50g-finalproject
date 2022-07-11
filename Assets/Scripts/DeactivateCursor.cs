using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
