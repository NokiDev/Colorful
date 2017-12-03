using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingPlateforme : MonoBehaviour {

    private Collider _ParentCollider;

	// Use this for initialization
	void Start () {
        _ParentCollider = gameObject.transform.parent.GetComponent<Collider>();
        
	}
	
	// Update is called once per frame
	void Update () {
	}
}
