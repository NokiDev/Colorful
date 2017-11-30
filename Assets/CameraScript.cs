using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject TargetObject;

    private Vector3 _Offset;

    // Use this for initialization
    private void Start()
    {
        _Offset = GetComponent<Transform>().position - TargetObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = TargetObject.transform.position + _Offset;
    }
}