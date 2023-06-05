using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ObjectiveValues", menuName = "ObjectiveValues")]
public class ObjectiveValues : ScriptableObject
{
    public bool[] objectiveValues;

    public bool gameStarted;
}
