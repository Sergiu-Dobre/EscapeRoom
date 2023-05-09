using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlacement : MonoBehaviour
{
    [SerializeField] private GameObject wheelPickUp;
   // [SerializeField] private GameObject targetPlacement;
    [SerializeField] private GameObject missingWheel;
    // Start is called before the first frame update   
    [SerializeField] private Animation anim;
    [SerializeField] private bool collideCheck;

    void Start()
    {


        
        
        //missingWheel.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
            if (collideCheck)
            {
           
            wheelPickUp.SetActive(false);
                anim.Play();
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            
            
            }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Wheel")

        {   
            Debug.Log("yes is colliding");
            collideCheck= true;
            Destroy(wheelPickUp);    
            // wheelPickUp.SetActive(false);
           // missingWheel.SetActive(false);
           // anim.Play();
        }
    }

}
