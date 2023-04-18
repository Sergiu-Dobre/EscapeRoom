using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenDoor : MonoBehaviour
{
    private bool openDoor;
    //temporary fix
    [SerializeField] GameObject door;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            openDoor = true;
        }
        else
        {
            openDoor = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (openDoor)
        {
            if (other.tag == "Player")
            {

                //TODO: play animation
                
                door.SetActive(false);


            }
        }
    }
}
