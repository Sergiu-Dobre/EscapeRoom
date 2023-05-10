using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveConroller : MonoBehaviour
{
    [SerializeField] GameObject pipe1;
    [SerializeField] GameObject pipe2;
    [SerializeField] GameObject pipe3;
    [SerializeField] GameObject pipe4;
    [SerializeField]private bool allowInteraction;
    [SerializeField]private Vector3 rescaleRandom;
    [SerializeField] private Vector3 rescaleRandom2;
    [SerializeField] private Vector3 rescaleRandom3;
    [SerializeField] private Vector3 rescale;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {   
        //rescaleRandom= new Vector3 (1f, Random.Range(1f,0.2f), 1f);
        //rescaleRandom2 = new Vector3(1f, Random.Range(1f, 0.2f), 1f);
        //rescaleRandom3 = new Vector3(1f, Random.Range(1f, 0.2f), 1f);
       
        allowInteraction = false;
        rescale = new Vector3(1f, 0.65f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            allowInteraction = true;
        }
        else
        {
            allowInteraction = false;
        }

    }
    private void OnTriggerStay (Collider other)
    {
        if (allowInteraction)
        {
            if (other.tag == "Player")
            {   
                audioSource.Play();
                // transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Debug.Log("colides wiht the valve");
                
                    pipe1.transform.localScale = rescaleRandom;
                    pipe2.transform.localScale = rescaleRandom2;
                    pipe3.transform.localScale = rescaleRandom3;
                    pipe4.transform.localScale = rescale;

            }
            
        }
       
    }
}
