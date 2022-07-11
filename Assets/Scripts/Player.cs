using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHp;
    int hp;

    public GameObject weapon;
    public bool isAttacking;

    public GameObject panel;
    Image image;
    public GameObject panel2;
    Image image2;

    public GameObject gameOverCanvas;
    private bool alreadyLost = false;
    
    // Start is called before the first frame update
    void Start() {
        isAttacking = false;

        image = panel.GetComponent<Image>();
        image2 = panel2.GetComponent<Image>();

        hp = maxHp;

        GameObject.FindGameObjectWithTag("HP").GetComponent<Text>().text = hp.ToString() + "/20 HP";
    }

    void Update() {
        // update canvas
        try {
            GameObject.FindGameObjectWithTag("HP").GetComponent<Text>().text = hp.ToString() + "/20 HP";
        } catch {}
        
        // if not paused, allow attacking
        if (Time.timeScale != 0f) {
            if (Input.GetMouseButtonDown(0)) {
                isAttacking = true;
                SwipeKnife();
            }
        }
        
        // die
        if (hp <= 0) {
            Die();
        }
        
        // clear canvas
        if (image.color.a > 0) {
            var color = image.color;
            color.a -= 0.1f;
            image.color = color;
        }
        if (image2.color.a > 0) {
            var color = image2.color;
            color.a -= 0.1f;
            image2.color = color;
        }
    }

    public void TakeDamage(int damage) {
        hp -= damage;

        var color = image.color;
        color.a = 0.8f;
        image.color = color;

        var color2 = image2.color;
        color2.a = 0.4f;
        image2.color = color2;

        // play player hurt sound
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        // GetComponents<FlashImage>()[0].StartFlash(.5f, .8f, Color.red);
        // GetComponents<FlashImage>()[1].StartFlash(.5f, .5f, Color.red);
    }
    private void Die() {
        Time.timeScale = 0f;
        // call Game Over canvas
        CallGameOverCanvas();
    }

    private void CallGameOverCanvas() {
        if (!alreadyLost) {
            // destroy canvas (except player's canvas)
            GameObject[] allCanvas = GameObject.FindGameObjectsWithTag("Canvas");
            for (int i = 1; i < allCanvas.Length; i += 1)
            {
                // Destroy(allCanvas[i]);
                allCanvas[i].SetActive(false);
            }

            // new Game Over canvas
            Instantiate(gameOverCanvas, new Vector3(0, 0, 0), Quaternion.identity);

            // pause time
            Time.timeScale = 0f;

            // pause player and activate cursor
            GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            alreadyLost = true;
        }
    }

    public void SwipeKnife() {
        // play sword swipe sound
        FindObjectOfType<AudioManager>().Play("SwordSwipe");

        weapon.transform.Rotate(60, 0, 0);
        StartCoroutine(SwipeBack(0.1f));
    }

    IEnumerator SwipeBack(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        weapon.transform.Rotate(-60, 0, 0);
        isAttacking = false;
    }

    // void OnTriggerEnter(Collider other) {
    //     if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Enemy>().dead) {
    //         other.gameObject.GetComponent<Enemy>().Carry();
    //     }
    // }
}
