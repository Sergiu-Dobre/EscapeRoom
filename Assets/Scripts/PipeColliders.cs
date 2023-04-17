using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColliders : MonoBehaviour
{
    [SerializeField] GameObject pipe1;
    [SerializeField] GameObject pipe2;
    [SerializeField] GameObject pipe3;
    [SerializeField] GameObject pipe4;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay(Collider     other)
    {

        if (other.tag=="pipe")
           //((pipe4.tag == "pipe") && (pipe2.tag == "DoorTrigger") && (pipe1.tag== "DoorTrigger") && (pipe3.tag=="DoorTrigger"))
        {
            door.SetActive(false);
        }
    }
}
