using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{

    // Use this for initialization
    bool _IsGrounded = true;
    Rigidbody _Rigidbody;

    private void Start()
    {
        _Rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (!_IsGrounded)//If we were in the air.
        {
            _Rigidbody.AddForce(-_Rigidbody.velocity, ForceMode.Impulse);//Cancel Velocity and start with a fresh one.
            _IsGrounded = true;
        }
    }
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
