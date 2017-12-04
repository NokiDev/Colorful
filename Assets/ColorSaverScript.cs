using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSaverScript : MonoBehaviour {

    public Color SavedColor;
    private PaintableBase paintable;
    private AbsorbableBase absorbable;
    private ParticleSystem _ParticleSystem;
    // Use this for initialization
    void Start()
    {
        _ParticleSystem = GetComponent<ParticleSystem>();
        _ParticleSystem.Stop();
        paintable = GetComponent<PaintableBase>();
        absorbable = GetComponent<AbsorbableBase>();
        paintable.OnPainted += (color) =>
        {   if(color == Color.black)
            {
                paintable.Paint(SavedColor);
            }
            else if(color != Color.grey)
            {
                ParticleSystem.MainModule main = _ParticleSystem.main;
                main.startColor = color;
                _ParticleSystem.Play();
                SavedColor = color;
            }
            
        };
        absorbable.OnAbsorbed += (color) =>
        {
            _ParticleSystem.Stop();
            paintable.Paint(SavedColor);
        };
        if (SavedColor != new Color(0f,0f,0f,0f))
        {
            paintable.Paint(SavedColor);
        }
    }
}
