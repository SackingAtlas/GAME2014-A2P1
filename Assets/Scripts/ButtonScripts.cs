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

    public GameObject playerReferance;
    public GameObject blinker;


    private void Start()
    {
        //cam = GetComponent<cam>();
        minZoom = cam.orthographicSize;
    }
    private void Update()
    {
        if (cam.orthographicSize <= 5)
        {
            blinker.SetActive(true);
            playerReferance.GetComponent<PlayeController>().buttonPressed = false;
        }
        else
        {
            blinker.SetActive(false);
            playerReferance.GetComponent<PlayeController>().buttonPressed = true;
        }

        if (zoomingIn == false)
        {
            if (cam.orthographicSize > minZoom)
            {
                cam.orthographicSize -= Time.deltaTime * zoom;
            }
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
        zoomingIn = true;
        playerReferance.GetComponent<PlayeController>().buttonPressed = true;
    }

    public void ZoomButtonReleased()
    {
        zoomingIn = false;
    }
}