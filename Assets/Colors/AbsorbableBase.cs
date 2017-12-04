using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbableBase : MonoBehaviour, IAbsorbable {

    public delegate void AbsorbtionObserver(Color color);
    public AbsorbtionObserver OnAbsorbed;

    private MeshRenderer _MeshRenderer;
	void Start () {
        _MeshRenderer = GetComponent<MeshRenderer>();
        OnAbsorbed += (color) => { };
	}

    public Color Absorb()
    {
        Color current = _MeshRenderer.material.color;
        Color finalColor = current;
        if(current != Color.black)
        {
            finalColor = Color.grey;
            _MeshRenderer.material.color = finalColor;

        }
        OnAbsorbed(finalColor);
        return current;
    }

    public Color GetColor()
    {
        return _MeshRenderer.material.color;
    }
}
