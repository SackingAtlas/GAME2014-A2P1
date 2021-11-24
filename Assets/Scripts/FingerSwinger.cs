using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerSwinger : MonoBehaviour
{
    bool isCutting;
    Rigidbody2D rb;
    public GameObject TrailPrefab;
    private GameObject currentTrail;

    CircleCollider2D circleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        touchHandler();
    }

    private void touchHandler()
    {
        foreach (Touch touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = new Vector3(worldTouch.x, worldTouch.y, 0);
                    HitterOn();
                    break;

                case TouchPhase.Moved:
                    transform.position = new Vector3(worldTouch.x, worldTouch.y, 0);
                    break;

                case TouchPhase.Ended:
                    HitterOff();
                    break;
            }
        }
    }

    void HitterOn()
    {
        isCutting = true;
        currentTrail = Instantiate(TrailPrefab, transform);
        circleCollider.enabled = true;
    }
    void HitterOff()
    {
        isCutting = false;
        Destroy(currentTrail);
        circleCollider.enabled = false;
    }

}
