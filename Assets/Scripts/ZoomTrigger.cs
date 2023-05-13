using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ZoomTrigger : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject Player;


    private void Start()
    {
        cam.GetComponent<ZoomIn>().enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            cam.GetComponent<ZoomIn>().enabled=(true);
            Debug.Log("is colliding");

        }       
    }

    private void OnTriggerExit(Collider other)
    {
        
        cam.GetComponent<ZoomIn>().enabled = false;
       
    }
   
}
