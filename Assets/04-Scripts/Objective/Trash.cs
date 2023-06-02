using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public AudioManager audioManager;
    public Objectives objectives;

    private int _collected;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        _collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_collected == 10 && !objectives.tasks[3].isOn)
        {
            objectives.Complete(3);
            audioManager.Play("taskcomplete");
            audioManager.Play("yawn");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash")
        {
            _collected++;
            Destroy(other.gameObject);
            audioManager.Play("trash");
        }
    }
}
