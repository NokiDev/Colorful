using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundScript : MonoBehaviour
{
    public float speed = 10f;
    private float rotation = 0f;

    void Start()
    {
    }

    void Update()
    {
        rotation += (0.5f * speed * Time.deltaTime);
        rotation %= 360f;
        transform.localRotation = Quaternion.AngleAxis(rotation, transform.up);
    }
}