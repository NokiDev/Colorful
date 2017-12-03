using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterScript : MonoBehaviour {

    public delegate void ColorObserver(Color newColor);
    public ColorObserver OnColorChanged;

    private MeshRenderer _MeshRenderer;

	// Use this for initialization
	void Start () {
        _MeshRenderer = GetComponent<MeshRenderer>();
        OnColorChanged += (color) => { Debug.Log(color); };
	}
	
    public void SetColor(Color newColor)
    {
        _MeshRenderer.material.color = newColor;
        OnColorChanged(newColor);
    }

    public Color GetColor()
    {
        return _MeshRenderer.material.color;
    }
}
