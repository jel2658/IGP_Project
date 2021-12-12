using UnityEngine.Audio;
using UnityEngine;

//CODE GOTTEN FROM Brackeys, Intro to AUDIO in Unity

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
