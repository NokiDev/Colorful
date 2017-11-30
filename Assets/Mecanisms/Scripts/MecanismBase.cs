using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MecanismBase : MonoBehaviour, IMecanism
{
    public bool Activated = false;

    protected delegate void MecanismObserver();

    protected MecanismObserver OnActivation;
    protected MecanismObserver OnDeactivation;

    private void Awake()
    {
        //Avoid getting no def on deactivation and activation delegates.
        OnActivation += () => { };
        OnDeactivation += () => { };
    }
    
    public void Activate()
    {
        Activated = true;
        OnActivation();
    }

    public void Deactivate()
    {
        Activated = false;
        OnDeactivation();
    }
}