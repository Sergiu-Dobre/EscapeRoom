using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveConroller : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField]private bool allowInteraction;
    [SerializeField]private Vector3 rescale; 

    // Start is called before the first frame update
    void Awake()
    {   
        rescale= new Vector3 (0.2f, 0.7f, 0.2f);
        allowInteraction = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            allowInteraction = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (allowInteraction)
        {
            if (other.tag == "Player")
            {

                // transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Debug.Log("colides wiht the valve");

                pipe.transform.localScale = rescale;
            }
        }
        else
            allowInteraction = false;
    }
}
