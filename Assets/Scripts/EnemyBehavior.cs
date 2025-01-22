using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
// 1
public Transform PatrolRoute;
// 2
public List<Transform> Locations;
void Start()
{
    // 3
InitializePatrolRoute();
}
// 4
void InitializePatrolRoute()
{
// 5
foreach(Transform child in PatrolRoute) {
// 6
Locations.Add(child);
}
}



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}