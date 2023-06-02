using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{
    public Collider cup;
    public Objectives objectives;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other == cup && objectives.triggers[0])
        {
            if (!objectives.tasks[2].isOn)
                StartCoroutine(playAudio());
            objectives.Complete(2);
            objectives.triggers[0] = false;
        }
    }

    IEnumerator playAudio()
    {
        audioManager.Play("taskcomplete");

        yield return new WaitForSeconds(1);

        audioManager.Play("gulp");

        yield return new WaitForSeconds(1.5f);
        audioManager.Play("yawn");
    }
}
