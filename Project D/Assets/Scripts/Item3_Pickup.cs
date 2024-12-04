using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3_Pickup : MonoBehaviour
{
    public float pickupRange = 2f; // Range within which the player can pick up the item
    public NPC_Dialogue npcDialogue; // Reference to the NPC_Dialogue script

    private bool isPlayerInRange = false;
    private SphereCollider pickupCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Add a SphereCollider and set it as a trigger
        pickupCollider = gameObject.AddComponent<SphereCollider>();
        pickupCollider.isTrigger = true;
        pickupCollider.radius = pickupRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupItem3();
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

    private void PickupItem3()
    {
        //Debug.Log("Item picked up!");

        if (npcDialogue != null)
        {
            //Debug.Log("Changing NPC dialogue");
            npcDialogue.item3PickedUp = true;
            npcDialogue.currentDialogueIndex = 6;
            npcDialogue.ChangeDialogue();
        }
        gameObject.SetActive(false); // Make the item disappear
    }
}
