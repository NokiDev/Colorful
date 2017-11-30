using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTestScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
        if (Input.GetKey(KeyCode.B))
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 10, transform.rotation.z));
        }
    }
}