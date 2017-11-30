
using UnityEngine;

public class BinaryActivator : MonoBehaviour, IMecanism
{
    public bool OneActivation = false;
    public bool Activated = false;

    public MecanismBase Mecanism = null;

    protected delegate void Activation();

    protected Activation OnActivate;
    protected Activation OnDeactivate;


    protected GameObject Player;
    private bool _HasBeenActivated;

    // Use this for initialization
    private void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
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

    protected void CheckInput()
    {
        if (Player == null || OneActivation && _HasBeenActivated || !Input.GetButtonDown("Action")) return;
        if (!Activated)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
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

    private void OnTriggerEnter(Collider c)
    {
        //Check look at.
        Player = gameObject;
    }

    private void OnTriggerExit(Collider c)
    {
        Player = null;
    }
}