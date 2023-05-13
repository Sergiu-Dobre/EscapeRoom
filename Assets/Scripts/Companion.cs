using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float followDistance = 1f; // Distance to follow the player at
    public float speed = 5f; // Speed of the companion

    // Update is called once per frame
    void Update()
    {
        // Get the position of the player
        Vector3 playerPos = playerTransform.position;

        // Set the companion's y position to be the same as the player's
        Vector3 companionPos = transform.position;
        companionPos.y = playerPos.y;
        transform.position = companionPos;

        // Calculate the direction from the companion to the player, but ignore the y component
        Vector3 direction = playerPos - companionPos;
        direction.y = 0f;

        // Calculate the distance to the player, but ignore the y component
        float distance = direction.magnitude;
        direction.Normalize();

        // If the companion is too far from the player horizontally, move towards them
        if (distance > followDistance)
        {
            // Move the companion horizontally towards the player, with a speed proportional to the distance
            transform.position += direction * speed * (distance - followDistance) * Time.deltaTime;
        }
    }
}
