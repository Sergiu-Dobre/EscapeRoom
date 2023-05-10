using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotspuzzle : MonoBehaviour
{

    public GameObject[] dots; // Array of dot prefabs
    public LineRenderer lineRenderer; // Reference to the line renderer component
    public GameObject puzzleCompleteText; // Reference to the text that appears when the puzzle is completed

    private List<GameObject> currentDots = new List<GameObject>(); // List of dots the player has currently selected
    private bool puzzleCompleted = false; // Whether the puzzle has been completed or not

    void Start () {
        SpawnDots(); // Spawn the dots at the start of the game
    }

    void Update () {
        // Check if the puzzle is completed
        if (!puzzleCompleted) {
            CheckForCompletion();
        }

        // Check for player input
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Dot") {
                AddDotToLine(hit.collider.gameObject);
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            ResetLine();
        }
        else if (Input.GetMouseButton(0)) {
            UpdateLine();
        }
    }

    void SpawnDots () {
        // Spawn the dots in a grid pattern
        int numDots = dots.Length;
        float xOffset = 1.5f;
        float yOffset = 1.5f;
        float startX = -(numDots / 2) * xOffset;
        float startY = (numDots / 2) * yOffset;

        for (int i = 0; i < numDots; i++) {
            for (int j = 0; j < numDots; j++) {
                Vector3 position = new Vector3(startX + (i * xOffset), startY - (j * yOffset), 0f);
                Instantiate(dots[i], position, Quaternion.identity);
            }
        }
    }

    void AddDotToLine (GameObject dot) {
        // Add the dot to the line and to the list of currently selected dots
        currentDots.Add(dot);
        lineRenderer.positionCount = currentDots.Count;
        lineRenderer.SetPosition(currentDots.Count - 1, dot.transform.position);
    }

    void UpdateLine () {
        // Update the line renderer to connect the currently selected dots
        if (currentDots.Count > 0) {
            lineRenderer.SetPosition(currentDots.Count - 1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void ResetLine () {
        // Clear the current list of selected dots and reset the line renderer
        currentDots.Clear();
        lineRenderer.positionCount = 0;
    }

    void CheckForCompletion () {
        // Check if the player has connected all the dots
        bool allDotsConnected = true;
        foreach (GameObject dot in dots) {
            if (!currentDots.Contains(dot)) {
                allDotsConnected = false;
                break;
            }
        }

        // If all dots are connected, the puzzle is complete
        if (allDotsConnected) {
            puzzleCompleted = true;
            puzzleCompleteText.SetActive(true);
        }
    }
}
