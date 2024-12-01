using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public TextMeshPro dialogueText;
    public string[] dialogues = { "Hello, Player!",
        "You Need to Find the cube first",
        "You Found the Cube",
        "The next cube is right behind you",
        "You Found The Second Cube" }; // Placeholders, these can be changed in inspector
    public int currentDialogueIndex = 0;
    public bool item1PickedUp = false; // Flag to check if the first item has been picked up
    public bool item2PickedUp = false; // Flag to check if the second item has been picked up
    public bool item3PickedUp = false; // Flag to check if the third item has been picked up

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
            if (currentDialogueIndex == 0 || (currentDialogueIndex == 2 && item1PickedUp)
                || (currentDialogueIndex == 4 && item2PickedUp)
                || (currentDialogueIndex == 6 && item3PickedUp))
            {
                dialogueText.text = dialogues[currentDialogueIndex];
                currentDialogueIndex++;
                if (currentDialogueIndex >= dialogues.Length)
                {
                    currentDialogueIndex = dialogues.Length - 1; // Ensure the index does not exceed the array length
                }
            }
            else if (currentDialogueIndex == 1 && !item1PickedUp)
            {
                // Show the first hint if the player hasn't found the first item
                dialogueText.text = dialogues[1];
            }
            else if (currentDialogueIndex == 3 && !item2PickedUp)
            {
                // Show the second hint if the player has picked up the first item but not the second
                dialogueText.text = dialogues[3];
            }
            else if (currentDialogueIndex == 5 && !item3PickedUp)
            {
                // Show the second hint if the player has picked up the first item but not the second
                dialogueText.text = dialogues[5];
            }
        }
    }
}
