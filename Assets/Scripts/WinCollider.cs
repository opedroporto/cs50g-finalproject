using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    public GameObject winCanvas;
    private bool alreadyWon = false;

    GameObject[] FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }

    // trigger win
    void OnTriggerEnter(Collider other) {
        if (!alreadyWon) {
            // if colliding with player
            if (other.gameObject.tag == "Player") {
                // destroy canvas
                // GameObject[] allCanvas = FindGameObjectsInLayer(5);
                GameObject[] allCanvas = GameObject.FindGameObjectsWithTag("Canvas");
                for (int i = 0; i < allCanvas.Length; i += 1)
                {
                    // Destroy(allCanvas[i]);
                    allCanvas[i].SetActive(false);
                }
                // new canvas
                Instantiate(winCanvas, new Vector3(0, 0, 0), Quaternion.identity);

                // pause time
                Time.timeScale = 0f;

                // pause player and activate cursor
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                // level passed
                GameInfo gameInfo = GameObject.FindObjectOfType<GameInfo>();
                if (gameInfo.currentLevel == gameInfo.unlockedLevels) {
                    gameInfo.unlockedLevels += 1;
                }


                // stop in play theme song
                FindObjectOfType<AudioManager>().Stop("InPlayTheme");

                // play sound
                FindObjectOfType<AudioManager>().Play("Win");

                // alreadyWon bool
                alreadyWon = true;
            }

        }
    }

    public void LoadMenu() {
        // stop in play theme song
        FindObjectOfType<AudioManager>().Stop("InPlayTheme");

        // time speed normal
        Time.timeScale = 1f;

        // load menu
        SceneManager.LoadScene("StartMenu");
    }
}
