using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1_Pickup : MonoBehaviour
{
    public float pickupRange = 2f; // Range within which the player can pick up the item
    public NPC_Dialogue npcDialogue; // Reference to the NPC_Dialogue script
    public AudioSource pickupSound; // Reference to the AudioSource component for the pickup sound
    public Transform playerTransform; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed at which the item moves towards the player

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
            PickupItem1();
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

    private void PickupItem1()
    {
        //Debug.Log("Item picked up!");

        if (npcDialogue != null)
        {
            //Debug.Log("Changing NPC dialogue");
            npcDialogue.item1PickedUp = true;
            npcDialogue.currentDialogueIndex = 2;
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
}