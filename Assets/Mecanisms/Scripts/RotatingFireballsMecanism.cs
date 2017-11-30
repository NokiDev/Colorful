using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFireballsMecanism : MecanismBase
{
    public float Speed = 10f;
    private float _Rotation = 0f;

    private void Start()
    {
      
    }

    private void Update()
    {
        if (Activated)
        {
            _Rotation += 0.5f * Speed * Time.deltaTime;
            _Rotation %= 360f;
            transform.localRotation = Quaternion.AngleAxis(_Rotation, transform.up);
        }
    }
}