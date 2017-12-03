using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlateformScript : MonoBehaviour {

    public int length;
    public float steps = 1f;//1 change every seconds;

    private MeshRenderer[] _MeshRenderers;
    private float timer = 0f;
    private int _Next = 0;
    // Use this for initialization
    void Start()
    {
        _MeshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        //TODO Place in a corouting.
        timer += Time.deltaTime;
        if(timer >= steps)
        {
            var last = _Next - length;
            if(last < 0)
                last = _MeshRenderers.Length + last;

            TurnToColor(last, Color.black);
            TurnToColor(_Next, Color.grey);

            //
            _Next++;
            if (_Next >= _MeshRenderers.Length)
                _Next = 0;
            else if (_Next < 0)
                _Next = _MeshRenderers.Length - 1;
            timer = 0.0f;
        }
	}

    private void TurnToColor(int index, Color newColor)
    {
        if (index < 0 || index >= _MeshRenderers.Length)
            return;
        _MeshRenderers[index].material.color = newColor;
    }
}
