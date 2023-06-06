using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    public CanvasGroup ui;
    public Camera player;
    public float radius = 2f;

    void Start()
    {
        player = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, ui.transform.position) < radius)
            ui.interactable = true;
        else
            ui.interactable = false;
    }
}
