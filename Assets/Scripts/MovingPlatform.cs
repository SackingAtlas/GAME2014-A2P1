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
        if (Vector2.Distance(bone.transform.position, end.position) < flipRadius)
            goToHere = start.position;
        if (Vector2.Distance(bone.transform.position, start.position) < flipRadius)
            goToHere = end.position;
        bone.transform.position = Vector2.MoveTowards(bone.transform.position, goToHere, speed * Time.deltaTime);
    }
}
