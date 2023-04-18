using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour
{
    public GameObject itemToPlace;
    public GameObject placedWheel;

    void Start()
    {
        placedWheel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wheel"))
        {
            itemToPlace.SetActive(false);
            placedWheel.SetActive(true);
        }
    }
}
