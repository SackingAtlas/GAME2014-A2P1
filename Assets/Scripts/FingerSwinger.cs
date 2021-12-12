using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerSwinger : MonoBehaviour
{
    CircleCollider2D circleCollider;

    void Start()
    {
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
                    break;

                case TouchPhase.Moved:
                    transform.position = new Vector3(worldTouch.x, worldTouch.y, 0);
                    HitterOn();
                    break;

                case TouchPhase.Ended:
                    HitterOff();
                    break;
            }
        }
    }

    void HitterOn()
    {
        circleCollider.enabled = true;
    }
    void HitterOff()
    {
        circleCollider.enabled = false;
    }

}
