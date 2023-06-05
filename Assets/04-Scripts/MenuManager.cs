using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MenuManager : MonoBehaviour
{
    public TeleportationArea teleportationArea;
    public DynamicMoveProvider dynamicMoveProvider;
    public ObjectiveManager objectiveManager;
    public Canvas startMenu;


    // Start is called before the first frame update
    void Start()
    {
        if (objectiveManager.ov.gameStarted == false)
        {
            objectiveManager.ResetValues();
            objectiveManager.UpdateObjectives();
            teleportationArea.enabled = false;
            dynamicMoveProvider.enabled = false;
            startMenu.gameObject.SetActive(true);
        }
    }

    void OnApplicationQuit()
    {
        objectiveManager.ov.gameStarted = false;
    }

    public void StartGame()
    {
        teleportationArea.enabled = true;
        dynamicMoveProvider.enabled = true;
        startMenu.gameObject.SetActive(false);
    }
}
