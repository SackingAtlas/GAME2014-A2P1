using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBoneScript : MonoBehaviour
{
    public GameObject toothPrefab;
    public Transform spawnPoint;
    public void Spawn()
    {
        Instantiate(toothPrefab, spawnPoint);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
