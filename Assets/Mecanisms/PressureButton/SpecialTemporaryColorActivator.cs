using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialTemporaryColorActivator : BinaryActivator
{
    public Color ActivationColor = Color.black;
    private MeshRenderer _MshRenderer;
    private PaintableBase _Paintable;

    public Canvas canvas;

    private void Start()
    {
        _MshRenderer = GetComponent<MeshRenderer>();
        _Paintable = GetComponent<PaintableBase>();
        _Paintable.OnPainted += CheckColor;
    }

    void CheckColor(Color newColor)
    {
        Debug.Log(ActivationColor + "  " + newColor);
        if (newColor == ActivationColor)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }

    public override void Activate()
    {

    }

    public override void Deactivate()
    {

    }
}