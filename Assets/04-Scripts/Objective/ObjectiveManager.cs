using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public Objectives objectives;
    public ObjectiveValues ov;

    // Start is called before the first frame update
    void Start()
    {
        if (objectives != null)
            for (int i = 0; i < objectives.tasks.Length; i++)
            {
                objectives.tasks[i].isOn = ov.objectiveValues[i];
            }
    }

    public void UpdateValues()
    {
        if (objectives != null)
            for (int i = 0; i < objectives.tasks.Length; i++)
            {
                ov.objectiveValues[i] = objectives.tasks[i].isOn;
            }
    }

    public void UpdateObjectives()
    {
        if (objectives != null)
            for (int i = 0; i < objectives.tasks.Length; i++)
            {
                objectives.tasks[i].isOn = ov.objectiveValues[i];
            }
    }

    public void ResetValues()
    {
        for (int i = 0; i < ov.objectiveValues.Length; i++)
        {
            ov.objectiveValues[i] = false;
        }
    }
}
