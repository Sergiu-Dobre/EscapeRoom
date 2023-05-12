using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactMessage = "Press E to interact";

    private bool canInteract = false;
    private bool isInteracting = false;

    public void Interact()
    {
        // Start interaction
        Debug.Log("Interaction started.");
        isInteracting = true;
    }

    public void StopInteract()
    {
        // End interaction
        Debug.Log("Interaction ended.");
        isInteracting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            if (isInteracting)
            {
                StopInteract();
            }
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            Interact();
        }
        else if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            StopInteract();
        }
    }

    private void OnGUI()
    {
        if (canInteract && !isInteracting)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), interactMessage);
        }
    }
}
