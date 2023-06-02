using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCupSocket : MonoBehaviour
{
    public Collider cup;
    public Objectives objectives;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider == cup && objectives.tasks[1].isOn && !objectives.triggers[0])
        {
            objectives.triggers[0] = true;
            audioManager.Play("waterpour");
        }
    }
}
