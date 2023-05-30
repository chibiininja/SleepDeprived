using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioManager audioManager;
    public string[] sounds;

    public void Play()
    {
        int randomIndex = Random.Range(0,sounds.Length);
        audioManager.Play(sounds[randomIndex]);
        Debug.Log("Playing " + sounds[randomIndex]);
    }
}
