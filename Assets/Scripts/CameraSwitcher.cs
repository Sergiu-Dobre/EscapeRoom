using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Camera alternativeCamera; // Reference to the alternative camera
    public float sensitivity = 2f; // Mouse sensitivity for camera movement

    private bool isAlternativeCameraActive = false;
    private bool canSwitchBack = false;
    private bool playerInRange = false;
    private float mouseX, mouseY;

    private void Start()
    {
        // Activate the main camera initially
        mainCamera.enabled = true;
        alternativeCamera.enabled = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isAlternativeCameraActive)
            {
                // Switch to the alternative camera
                isAlternativeCameraActive = true;
                mainCamera.enabled = false;
                alternativeCamera.enabled = true;
                canSwitchBack = true;

                // Lock and hide the cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (canSwitchBack)
            {
                // Switch back to the main camera
                isAlternativeCameraActive = false;
                mainCamera.enabled = true;
                alternativeCamera.enabled = false;
                canSwitchBack = false;

                // Unlock and show the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (isAlternativeCameraActive)
        {
            // Handle mouse movement for the alternative camera
            mouseX += Input.GetAxis("Mouse X") * sensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

            mouseY = Mathf.Clamp(mouseY, -90f, 90f);

            alternativeCamera.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the appropriate tag of the player object
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the appropriate tag of the player object
        {
            playerInRange = false;
        }
    }
}
