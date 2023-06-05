using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public Trash trash;

    // Update is called once per frame
    void Update()
    {
        counterText.text = "Remaining: " + trash.remaining.ToString();
    }
}
