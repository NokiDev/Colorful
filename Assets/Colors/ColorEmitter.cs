using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEmitter : MonoBehaviour {


    private IPaintable[] _Paintables = { };
    public ColorDetectorScript _Detector;
    MeshRenderer _MeshRenderer;
	// Use this for initialization
	void Start () {
        //_Detector = GetComponent<ColorDetectorScript>();
        _MeshRenderer = GetComponent<MeshRenderer>();
        _Detector.OnPaintableChanged += PaintableChanged;
	}


    void PaintableChanged(IPaintable[] paintables)
    {
        Debug.Log(paintables.Length);
        _Paintables = paintables;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Paint"))//Change for paint or emit
        {
            foreach(var paintable in _Paintables)
            {
                paintable.Paint(_MeshRenderer.material.color);
            }
        }
	}
}
