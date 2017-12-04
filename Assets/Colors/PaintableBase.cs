using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableBase : MonoBehaviour, IPaintable {

    public delegate void PaintableObserver(Color NewColor);
    public PaintableObserver OnPainted;

    MeshRenderer _MeshRenderer;
	// Use this for initialization
	void Awake () {
        _MeshRenderer = GetComponent<MeshRenderer>();
	}

    public void Paint(Color newColor)
    {
        _MeshRenderer.material.color = newColor;
        OnPainted(newColor);
    }

    public Color GetColor()
    {
        return _MeshRenderer.material.color;
    }
}
