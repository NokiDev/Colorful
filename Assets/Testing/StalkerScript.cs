using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerScript : MonoBehaviour
{
    public Transform target;

    //public float speed = 1f;
    private Transform myTr;


    // Use this for initialization
    void Start()
    {
        myTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = myTr.localPosition;
        myTr.localPosition = Vector3.Lerp(myTr.localPosition, target.localPosition, Time.deltaTime);
    }
}