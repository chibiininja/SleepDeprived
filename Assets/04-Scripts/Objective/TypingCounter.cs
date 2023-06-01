using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingCounter : MonoBehaviour
{
    public Objectives objectives;
    public TMP_Text counterText;
    public int counter = 0;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = counter.ToString();
        if (counter >= 100 && !objectives.tasks[0].isOn)
        {
            objectives.Complete(0);
            audioManager.Play("taskcomplete");
            audioManager.Play("yawn");
        }
    }

    public void incrementCounter()
    {
        counter++;
    }
}
