using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{

    // Use this for initialization
    bool _IsGrounded = true;

    private void OnTriggerStay(Collider coll)
    {
        _IsGrounded = true;
    }

    private void OnTriggerExit(Collider coll)
    {
        _IsGrounded = false;
    }

    public bool IsGrounded()
    {
        return _IsGrounded;
    }
}
