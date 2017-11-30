using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToScript : MonoBehaviour
{
    // Use this for initialization

    public Transform Destination;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(Destination.position);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}