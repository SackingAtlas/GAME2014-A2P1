using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform player;
    public float smoothness;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 newPosition = Vector3.Lerp(transform.position, playerPosition, smoothness * Time.deltaTime);
        transform.position = newPosition;
    }
}
