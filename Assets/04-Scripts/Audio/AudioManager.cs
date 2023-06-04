using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public bool debug = false;
    public Sound[] sounds;
    public Sound[] musics;

    private int _selected;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }
    }

    private void Start()
    {
        PlayMusic("officeambience");
        _selected = 0;
    }

    private void Update()
    {
        if (debug)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Playing: " + sounds[_selected].name);
                sounds[_selected].source.Play();
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                _selected--;
                if (_selected < 0)
                    _selected = sounds.Length - 1;
                Debug.Log("Selected: " + sounds[_selected].name);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                _selected++;
                if (_selected >= sounds.Length)
                    _selected = 0;
                Debug.Log("Selected: " + sounds[_selected].name);
            }
        }
    }

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
        Debug.Log("Playing " + name);
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musics, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("Music: " + name + " not found!");
            return;
        }

        s.source.Play();
        Debug.Log("Playing " + name);
    }
}
