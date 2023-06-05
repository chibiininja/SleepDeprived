using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public AudioManager audioManager;
    public Objectives objectives;

    public int remaining = 10;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining == 0 && !objectives.tasks[3].isOn)
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
            remaining--;
            Destroy(other.gameObject);
            audioManager.Play("trash");
        }
    }
}
