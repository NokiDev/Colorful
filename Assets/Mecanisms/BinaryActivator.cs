
using UnityEngine;

public class BinaryActivator : MonoBehaviour, IMecanism
{
    public bool OneActivation = false;
    public bool Activated = false;

    public MecanismBase Mecanism = null;

    public delegate void Activation();

    public Activation OnActivate;
    public Activation OnDeactivate;

    private bool _HasBeenActivated;

    // Use this for initialization
    private void Start()
    {
        SetUp();
    }

    protected void SetUp()
    {
        OnActivate += () => Mecanism.Activate();
        OnDeactivate += () => Mecanism.Deactivate();
        if (Activated)
            OnActivate();
        else
            OnDeactivate();
    }

    public virtual void Activate()
    {
        OnActivate();
        Activated = true;
        _HasBeenActivated = true;
    }

    public virtual void Deactivate()
    {
        OnDeactivate();
        Activated = false;
    }
}