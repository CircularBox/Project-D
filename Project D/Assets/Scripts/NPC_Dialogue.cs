using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public TextMeshPro dialogueText;
    public string[] dialogues = { "Hello, Player!", "How are you today?" };
    private int currentDialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueText == null)
        {
            dialogueText = GetComponentInChildren<TextMeshPro>();
        }
    }

    public void ChangeDialogue()
    {
        Debug.Log("Dialogue Started");
        if (dialogueText != null && dialogues.Length > 0)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Length;
        }
    }
}
