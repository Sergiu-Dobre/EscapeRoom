using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlacement : MonoBehaviour
{
    [SerializeField] private GameObject wheelPickUp;
    [SerializeField] private GameObject targetPlacement;
    [SerializeField] private GameObject missingWheel;
    // Start is called before the first frame update    
    void Start()
    {
        missingWheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Wheel")

        {   
            wheelPickUp.SetActive(false);
            missingWheel.SetActive(true);
        }
    }

}
