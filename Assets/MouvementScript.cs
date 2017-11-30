using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouvementScript : MonoBehaviour
{
    public float MovementSpeed = 50.0f;
    public float MaxVelocityChange = 10f;
    public float RotateSpeed = 100.0f;
    public float JumpModifier = 10.0f;

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
        /*if (h != 0.0f) //Rotation with left and right. But may change.
           {
               _RotationAngle += Time.deltaTime * h;
               _RotationAngle %= 360;
               _RigidBody.AddForce((-transform.forward * v * 0.5f));
               _Transform.localRotation = Quaternion.AngleAxis(_RotationAngle, transform.up);
           }*/

        if (_GroundChecker.IsGrounded())//If ground allow to move and jump
        {
            var v = Input.GetAxis("Vertical");
            var h = Input.GetAxis("Horizontal");
            var velocity = new Vector3(h, 0, v); 
            velocity = transform.TransformDirection(velocity);
            velocity *= MovementSpeed;
            Vector3 velocityChange = velocity - _RigidBody.velocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocityChange, MaxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocityChange, MaxVelocityChange);
            velocityChange.y = 0;

            _RigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
            //Jumping
            if (Input.GetButtonDown("Jump")&& _GroundChecker.IsGrounded())
            {
                //Jump
                _RigidBody.velocity = new Vector3(_RigidBody.velocity.x, JumpModifier, _RigidBody.velocity.z);
            }
        }
        else
        {
            var velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity = transform.TransformDirection(velocity);
            velocity *= MovementSpeed/2;
            Vector3 velocityChange = velocity - _RigidBody.velocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocityChange, MaxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -MaxVelocityChange, MaxVelocityChange);
            velocityChange.y = 0;

            _RigidBody.AddForce(velocityChange, ForceMode.Force);
            
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