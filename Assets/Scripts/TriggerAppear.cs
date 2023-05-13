using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAppear : MonoBehaviour
{
    public GameObject objectToAppear; // The object to appear when triggered

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToAppear.SetActive(true); // Make the object to appear active
        }
    }
}

