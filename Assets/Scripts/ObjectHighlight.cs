using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class ObjectHighlight : MonoBehaviour
{

    private float interactionRange = 5.0f;
    private Camera playerCamera;
    private Vector3 screenCenter;
    private GameObject currentTarget;
    private int defaultMask;
    private int highlightMask;

    public delegate void HoverNewObjectHandler(GameObject target);
    public event HoverNewObjectHandler OnHoverNewObject;

    public delegate void ExitHoverHandler(GameObject target);
    public event ExitHoverHandler OnExitHover;

    private void Awake()
    {

        screenCenter = new Vector3(Screen.width >> 1, Screen.height >> 1);
        defaultMask = LayerMask.NameToLayer("Default");
        highlightMask = LayerMask.NameToLayer("Highlight");

    }

    private void Update()
    {

        if (playerCamera == null)
        {

            playerCamera = FindCamera();

        }

        else if (currentlyPointing)
        {

            RaycastHit info;
            if (Physics.Raycast(playerCamera.ScreenPointToRay(screenCenter), out info, interactionRange, LayerMask.GetMask("Default", "Highlight")))
            {

                GameObject target = info.collider.gameObject;

                if (currentTarget != target)
                {

                    OnHoverNewObject?.Invoke(target);
                    currentTarget = target;
                    currentTarget.layer = highlightMask;

                }

            }
            else if (currentTarget != null)
            {

                currentTarget.layer = defaultMask;
                OnExitHover?.Invoke(currentTarget);
                currentTarget = null;


            }
        }
    }

    private Camera FindCamera()
    {
        // Find and return the main camera in the scene
        return Camera.main;
    }

    // Define the currentlyPointing variable
    private bool currentlyPointing = true;

}
