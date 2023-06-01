using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public int counter = 0;

    // Update is called once per frame
    void Update()
    {
        counterText.text = counter.ToString();
    }

    public void incrementCounter()
    {
        counter++;
    }
}
