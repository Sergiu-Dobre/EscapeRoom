using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using static Dialogue;
using static DialogueManager;

public class Interaction : MonoBehaviour
{

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {

                Debug.Log("collider");

            }

        }
        

    }

}

