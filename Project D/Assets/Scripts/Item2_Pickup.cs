using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2_Pickup : MonoBehaviour
{
    public float pickupRange = 2f; // Range within which the player can pick up the item
    public NPC_Dialogue npcDialogue; // Reference to the NPC_Dialogue script
    public GameObject doorPOS1; // Reference to the close door position
    public GameObject doorPOS2; // Reference to the open door position

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
            PickupItem2();
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

    private void PickupItem2()
    {
        //Debug.Log("Item picked up!");

        if (npcDialogue != null)
        {
            //Debug.Log("Changing NPC dialogue");
            npcDialogue.item2PickedUp = true;
            npcDialogue.currentDialogueIndex = 4;
            npcDialogue.ChangeDialogue();
        }

        // Make the item disappear
        gameObject.SetActive(false);

        // Change the position of the door in the house
        Opendoor();
    }

    private void Opendoor()
    {
        if (doorPOS1 != null)
        {
            doorPOS1.SetActive(false); // Make doorPOS1 disappear
        }

        if (doorPOS2 != null)
        {
            doorPOS2.SetActive(true); // Make doorPOS2 appear
        }
    }
}
