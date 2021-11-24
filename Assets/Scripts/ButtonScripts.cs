using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    public Camera cam;
    public float zoom = 2;
    public float minZoom = 5;
    public float maxZoom = 20;
    public bool buttonTouched = false;
    private bool zoomingIn = false;


    private void Start()
    {
        //cam = GetComponent<cam>();
        minZoom = cam.orthographicSize;
    }
    private void Update()
    {
        if(zoomingIn == false)
        {
            if (cam.orthographicSize > minZoom)
            {
                cam.orthographicSize -= Time.deltaTime * zoom;
            }
            else
                buttonTouched = false;
        }
        else
        {
            if (cam.orthographicSize <= maxZoom)
            {
                cam.orthographicSize += Time.deltaTime * zoom;
            }
        }
    }
    public void ZoomButtonPressed()
    {
        buttonTouched = true;
        zoomingIn = true;
    }

    public void ZoomButtonReleased()
    {
        zoomingIn = false;
    }
}