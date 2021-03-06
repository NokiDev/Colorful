﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorActivator : BinaryActivator
{
    public Color ActivationColor = Color.black;
    private MeshRenderer _MshRenderer;
    private PaintableBase _Paintable;

    private void Start()
    {
        _MshRenderer = GetComponent<MeshRenderer>();
        _Paintable = GetComponent<PaintableBase>();
        _Paintable.OnPainted += CheckColor;
        SetUp();
    }

    void CheckColor(Color newColor)
    {
        if(newColor == ActivationColor)
        {
            base.Activate();
        }
        else
        {
            base.Deactivate();
        }
    }

    public override void Activate()
    {
       
    }

    public override void Deactivate()
    {
        
    }
}