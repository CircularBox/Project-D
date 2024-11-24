using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public TextMeshPro dialogueText;
    public string[] dialogues = { "Hello, Player!", "You Found the Cube" };
    public int currentDialogueIndex = 0;
    public bool itemPickedUp = false; // Flag to check if the item has been picked up

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
            if (currentDialogueIndex == 0 || itemPickedUp)
            {
                dialogueText.text = dialogues[currentDialogueIndex];
                currentDialogueIndex++;
                if (currentDialogueIndex >= dialogues.Length)
                {
                    currentDialogueIndex = dialogues.Length - 1; // Ensure the index does not exceed the array length
                }
            }
        }
    }
}
