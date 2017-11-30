using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouvementScript : MonoBehaviour
{
    public float MovementSpeed = 50.0f;
    public float MaxSpeed = 25.0f;
    public float RotateSpeed = 100.0f;

    private Rigidbody _RigidBody;
    private Transform _Transform;
    private float _RotationAngle = 0f;

    private bool _IsClimbing = false;
    public float ClimbingModifier = 0.5f;

    public GameObject GroundChecker;
    private GroundCheckScript _GroundChecker;
    private void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
        _Transform = GetComponent<Transform>();
        _GroundChecker = GroundChecker.GetComponent<GroundCheckScript>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * RotateSpeed;
        float v = Input.GetAxis("Vertical") * MovementSpeed;

        if (_IsClimbing)
        {
            if (v != 0.0f)
            {
                if (_RigidBody.velocity.magnitude < MaxSpeed)
                {
                    _RigidBody.AddForce(transform.up * v * ClimbingModifier);
                }
            }
            if (h != 0.0f)
            {
                if (_RigidBody.velocity.magnitude < MaxSpeed)
                {
                    _RigidBody.AddForce(transform.right * h * ClimbingModifier * 0.5f);
                }
            }
        }
        else
        {
            v = (!_GroundChecker.IsGrounded()) ? v / 2 : v;

            if (h != 0.0f) //Rotation with left and right. But may change.
            {
                _RotationAngle += Time.deltaTime * h;
                _RotationAngle %= 360;
                _RigidBody.AddForce((-transform.forward * v* 0.5f));// Cancel completely the force 
                _Transform.localRotation = Quaternion.AngleAxis(_RotationAngle, transform.up);
            }
            if (v != 0.0f)
            {
                if (_RigidBody.velocity.magnitude < MaxSpeed) //Be sure we don't go too fast.
                {
                    _RigidBody.AddForce((transform.forward * v), ForceMode.Acceleration);
                }
            }
            else//Decrease velocity.
            {
                 _RigidBody.AddForce(-transform.forward * v, ForceMode.Impulse); //Cancel Inertia
            }
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)&& _GroundChecker.IsGrounded())
        {
            //Jump
            _RigidBody.AddForce(transform.up * 10f, ForceMode.Impulse);
        }
    }

    public void SetClimbingMode(bool activated)
    {
        _IsClimbing = activated;
        if (activated)
        {
            _RigidBody.useGravity = false;
        }
        else
        {
            _RigidBody.useGravity = true;
        }
    }
}