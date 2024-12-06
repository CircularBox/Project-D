using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2_Pickup : MonoBehaviour
{
    public float pickupRange = 2f; // Range within which the player can pick up the item
    public NPC_Dialogue npcDialogue; // NPC_Dialogue script
    public AudioSource pickupSound; // AudioSource component for the pickup sound
    public Transform playerTransform; 
    public float moveSpeed = 5f; // Speed at which the item moves towards the player
    public GameObject doorPOS1; 
    public GameObject doorPOS2; 

    private bool isPlayerInRange = false;
    private SphereCollider pickupCollider;

    // Start is called before the first frame update
    void Start()
    {
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

        // Play the pickup audio
        if (pickupSound != null)
        {
            pickupSound.Play();
            Debug.Log("Playing pickup sound");
        }

        // Start the coroutine to move the item towards the player and remove it after a delay
        StartCoroutine(MoveItemTowardsPlayerAndRemove(1f)); // 1 second delay

        // Change the position of the door in the house
        Opendoor();
    }

    private IEnumerator MoveItemTowardsPlayerAndRemove(float delay)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < delay)
        {
            transform.position = Vector3.Lerp(initialPosition, playerTransform.position, elapsedTime / delay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = playerTransform.position; // Ensure the item reaches the player

        gameObject.SetActive(false); // Make the item disappear
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