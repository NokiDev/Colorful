using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorActivator : BinaryActivator
{
    public Color ActivationColor = Color.black;
    private MeshRenderer _MshRenderer;

    private void Start()
    {
        _MshRenderer = GetComponent<MeshRenderer>();
        SetUp();
    }

    private void Update()
    {
        CheckInput();
    }

    public override void Activate()
    {
        _MshRenderer.material.color = Player.GetComponent<MeshRenderer>().material.color;
        if (ActivationColor == _MshRenderer.material.color)
        {
            base.Activate();
        }
    }

    public override void Deactivate()
    {
        _MshRenderer.material.color = Player.GetComponent<MeshRenderer>().material.color;
        if (ActivationColor != _MshRenderer.material.color)
        {
            base.Deactivate();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.name);
        //Keep Reference to the Player
        Player = c.gameObject;
    }

    private void OnTriggerExit(Collider c)
    {
        //Clear reference
        Player = null;
    }
}