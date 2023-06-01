using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJugSocket : MonoBehaviour
{
    public Collider fullWaterJug;
    public Objectives objectives;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider == fullWaterJug && !objectives.tasks[1].isOn)
        {
            objectives.Complete(1);
            audioManager.Play("taskcomplete");
            audioManager.Play("yawn");
        }
    }
}
