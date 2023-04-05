using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    [SerializeField] private int zoom = 15;
    public int normal = 60;
    public float smooth = 5;
    public bool isZoomed = false;
    private bool notZoomed = true;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);

        }
        if (Input.GetMouseButton(1))
        {
            isZoomed = !notZoomed;
        }
        if (notZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}