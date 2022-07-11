using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

   void Awake() {

        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
       }
   }

    // void Start () {
    //     Play("MenuTheme");
    // }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void Stop (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    public void Pause (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Pause();
    }
    public void UnPause (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }
}
