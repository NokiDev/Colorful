using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButtonAnim : MonoBehaviour {

     
    private Animator _Animator;
    private BinaryActivator _Activator;
    
	// Use this for initialization
	void Start () {
        _Animator = GetComponentInParent<Animator>();
        _Activator = GetComponent<BinaryActivator>();
        _Activator.OnActivate += () => { RunAnimation(true); };
        _Activator.OnDeactivate += () => { RunAnimation(false); };
    }

    void RunAnimation(bool activate)
    {
        _Animator.SetBool("activated", activate);
    }



}
