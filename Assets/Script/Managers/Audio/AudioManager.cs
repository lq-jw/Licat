using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private Sound[] bgmSounds, seSounds;
    [SerializeField] private AudioSource bgmSource, seSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // PlayBGM("lv1_water");
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(bgmSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    public void PlaySE(string name)
    {
        Sound s = Array.Find(seSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            seSource.PlayOneShot(s.clip);
        }
    }

    public void UpdateVolume()
    {
        float bgmVolume = GameManager.instance.GetVolume("bgmVolume");
        float seVolume = GameManager.instance.GetVolume("seVolume");

        if (bgmVolume < 0) Debug.Log("Can not get bgm volume.");
        if (seVolume < 0) Debug.Log("Can not get se volume.");

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;
    }
}
