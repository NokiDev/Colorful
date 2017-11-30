using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GroundRenderQueue : MonoBehaviour {

    // Use this for initialization
    private MeshRenderer _Renderer;
	void Start () {
        _Renderer = GetComponent<MeshRenderer>();
        Debug.Log(_Renderer.material.renderQueue);
        _Renderer.material.renderQueue = ((int)RenderQueue.Geometry)-10;
        Debug.Log(_Renderer.material.renderQueue);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
