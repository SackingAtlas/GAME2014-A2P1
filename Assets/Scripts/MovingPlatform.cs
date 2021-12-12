using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed, flipRadius;
    [SerializeField] private Transform start, end;
    [SerializeField] private GameObject bone;
    private Vector2 goToHere;
    private void Start()
    {
        goToHere = end.position;
    }
    void Update()
    {
        if (bone.transform.position == end.position)
            goToHere = start.position;
        if (bone.transform.position == start.position)
            goToHere = end.position;
        bone.transform.position = Vector2.MoveTowards(bone.transform.position, goToHere, speed * Time.deltaTime);
    }
}
