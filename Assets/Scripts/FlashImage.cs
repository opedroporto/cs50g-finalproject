using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashImage : MonoBehaviour {

    public GameObject panel;

    Image image;

    Coroutine currentFlashRoutine = null;
    
    // Start is called before the first frame update
    void Start() {
        image = panel.GetComponent<Image>();
    }
    
    public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor) {
        image.color = newColor;

        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (currentFlashRoutine != null)
            StopCoroutine(currentFlashRoutine);
        currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlpha) {
        // animate flash in
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime) {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            image.color = colorThisFrame;

            // wait until the next frame
            yield return null;
        }
        // animate flash out
        float flashOutDuration = secondsForOneFlash / 2;

        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime) {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            image.color = colorThisFrame;

            // wait until the next frame
            yield return null;
        }
    }
}
