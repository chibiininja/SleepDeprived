using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text lines;
    public GameObject dialogueBubble;
    public Button dialogueButton;
    public Animator npc;
    public Dialogue dialogue;
    public ObjectiveValues ov;
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        int counter = 0;
        foreach (bool value in ov.objectiveValues)
        {
            if (value)
                counter++;
        }

        npc.SetInteger("TasksCompleted", counter);
    }

    void Update()
    {
        npc.SetBool("Visited", ov.visited);
    }

    public void StartDialogue()
    {
        StartCoroutine(BeginDialogue());
    }
    public IEnumerator BeginDialogue()
    {
        npc.SetBool("inDialogue", true);
        dialogueButton.interactable = false;
        yield return new WaitForSeconds(.2f);
        GameObject clone = Instantiate(dialogueBubble);
        clone.SetActive(true);
        lines = clone.GetComponentInChildren<TMP_Text>();
        audioManager.Play("saunder_talk");
        lines.text = dialogue.text;
        yield return new WaitForSeconds(10f);
        Destroy(clone);
        audioManager.Stop("saunder_talk");
        dialogueButton.interactable = true;
        npc.SetBool("inDialogue", false);
    }

    public void SetDialogue(Dialogue new_dialogue)
    {
        dialogue = new_dialogue;
    }

    public void SetVisited(bool value)
    {
        ov.visited = value;
    }
}
