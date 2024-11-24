using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1_Pickup : MonoBehaviour
{
    public float pickupRange = 2f; // Range within which the player can pick up the item
    public NPC_Dialogue npcDialogue; // Reference to the NPC_Dialogue script

    private bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void PickupItem()
    {
        //Debug.Log("Item picked up!");

        // Change the NPC's dialogue to the second index
        if (npcDialogue != null)
        {
            //Debug.Log("Changing NPC dialogue");
            npcDialogue.itemPickedUp = true;
            npcDialogue.currentDialogueIndex = 1;
            npcDialogue.ChangeDialogue();
        }
        gameObject.SetActive(false); // Make the item disappear
    }
}
