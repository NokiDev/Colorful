using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour {

    public Color paintingColor;
    private ParticleSystem _ParticleSystem;
	// Use this for initialization
	void Start () {
        _ParticleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = _ParticleSystem.main;
        main.startColor = paintingColor;
    }

    private void OnTriggerEnter(Collider coll)
    {
        var objectPainter = coll.gameObject.GetComponent<PainterScript>();
        if (objectPainter)
        {
            objectPainter.SetColor(paintingColor);
        }
    }
}
