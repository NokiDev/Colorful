using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingScript : MonoBehaviour
{
    // Use this for initialization
    private MeshRenderer _MeshRenderer;

    private void Start()
    {
        _MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        var collider = coll.collider;
        //Check only entities. 
        //Set Climb Mode.
        Debug.Log(collider.gameObject.name);
        var pRenderer = collider.GetComponentInParent<MeshRenderer>();
        var moveScript = collider.GetComponent<MouvementScript>();
        if (moveScript && pRenderer)
        {
            if (_MeshRenderer.material.color == pRenderer.material.color)
            {
                moveScript.SetClimbingMode(true);
            }
        }
        //Set rotation for the collider allowing it to stick to the wall.
    }

    private void OnCollisionExit(Collision coll)
    {
        var collider = coll.collider;

        if (collider)
        {
            if (collider.GetComponent<MouvementScript>())
            {
                collider.GetComponent<MouvementScript>().SetClimbingMode(false);
            }
            Debug.Log(collider);
        }
    }
}