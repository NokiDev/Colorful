using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvementScript : MonoBehaviour {

    public Transform PlayerTransform;
    public Transform SphereTransform;
    public Vector3 Offset;

    public float verticalSpeed;
    public float horizontalSpeed;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("RHorizontal");
        float v = Input.GetAxis("RVertical");
        //Look At Player. // Or center of the screen.
        //Translate through a spherical line 
        // Standard Camera Position 
        // W -> Translate Camera along the X axis
        // S -> Translate Camera along the -Xaxis
        // D -> Translate Camera along the Zaxis
        // A -> Translate Camera along the -Zaxis
        // Subject Camera Position => When Camera position is in the player view.
        //var relativePos = ((SphereTransform.position + Offset) - transform.position);
        //transform.position = relativePos;
        transform.LookAt(SphereTransform);
/*
        var rotation = Quaternion.LookRotation(relativePos);//Store camera rotation for the slerp.

        Quaternion current = transform.localRotation;
        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);*/


        transform.Translate(h * horizontalSpeed * Time.deltaTime, v * verticalSpeed * Time.deltaTime, 0f);
        transform.LookAt(PlayerTransform);
        //EulerAngles works with angles from 0 to 360

    }
}
