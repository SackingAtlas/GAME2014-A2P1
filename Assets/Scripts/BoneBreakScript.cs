using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneBreakScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("break");
        }
    }

    public void DestoryThis()
    {
        Destroy(gameObject);
    }
}
