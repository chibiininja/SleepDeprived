using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    public Toggle[] tasks;

    public void Complete(int i)
    {
        tasks[i].isOn = true;
    }
}
