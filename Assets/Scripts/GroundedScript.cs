using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{

    public bool isGrounded;
    public bool hitWall;
    public float wallPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            hitWall = true;
            wallPosition = collision.transform.position.x;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
        if (collision.gameObject.tag == "Wall")
        {
            hitWall = false;
        }
    }
}

