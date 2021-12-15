using UnityEngine;
using System;
using UnityEngine.Audio;

//CODE GOTTEN FROM Brackeys, Intro to AUDIO in Unity

public class AudioManager: MonoBehaviour
{

    public Sound[] GunShots;
    public Sound[] pumpAction;
    public Sound[] GrenadeLauncher;
    public Sound[] Music;

    public string theme;


    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in GunShots)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        foreach (Sound s in pumpAction)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        foreach (Sound s in GrenadeLauncher)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        foreach (Sound s in Music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlayMusic(theme);
    }

    public void PlayGunshot(string name)
    {
        Sound s = Array.Find(GunShots, sound => sound.name == name);
        s.source.Play();
    }
    public void PlayPumpAction(string name)
    {
        Sound s = Array.Find(pumpAction, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayGrenadeLauncher(string name)
    {
        Sound s = Array.Find(GrenadeLauncher, sound => sound.name == name);
        s.source.Play();
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(Music, sound => sound.name == name);
        s.source.Play();
    }
}
