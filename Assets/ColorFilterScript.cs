using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFilterScript : MonoBehaviour {

    private MeshRenderer _MeshRenderer;
	// Use this for initialization
	void Start () {
        _MeshRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {

    }

    void OnTriggerExit(Collider coll)
    {
        var painterObject = coll.gameObject.GetComponent<PainterScript>();
        if (painterObject)
        {
            Color c = painterObject.GetColor();
            float r = c.r - _MeshRenderer.material.color.r;
            float g = c.g - _MeshRenderer.material.color.g;
            float b = c.b - _MeshRenderer.material.color.b;

            if (r < 0.0f)
                r = 0.0f;
            if (g < 0.0f)
                g = 0.0f;
            if (b < 0.0f)
                b = 0.0f;

            painterObject.SetColor(new Color(r, g, b, 1.0f));
        }
    }
}
