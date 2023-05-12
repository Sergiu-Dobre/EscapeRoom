using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextPopUp : MonoBehaviour
{
    [SerializeField]
    private Image MessageImage;

    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessageImage.enabled = true;

            
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MessageImage.enabled = false;
            
        }
    }
}