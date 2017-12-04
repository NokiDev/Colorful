using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInfoScript : MonoBehaviour
{
    public GameObject ColorChecker;
    private MeshRenderer _MeshRenderer;
    private MeshRenderer _PlayerMeshRenderer;
    private Color _CurrentColor;
    private Animator _Animator;
    private PainterScript _PlayerPainter;

    private IAbsorbable[] _Absorbables;


    // Use this for initialization
    private void Start()
    {
        _MeshRenderer = GetComponent<MeshRenderer>();
        _Animator = GetComponent<Animator>();
        _PlayerMeshRenderer = transform.parent.gameObject.GetComponent<MeshRenderer>();

        _PlayerPainter = GetComponentInParent<PainterScript>();

        _PlayerPainter.OnColorChanged += UpdateColorInfo;
        ColorChecker.GetComponent<ColorDetectorScript>().OnAbsorbablesChanged += UpdateDetectedColor;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((_MeshRenderer.material.color != _PlayerMeshRenderer.material.color))
        {
            //Maybe do something different if we are black or consider it's a death color.
            if (Input.GetButtonDown("Absorb")) // Swap Colors
            {
                _PlayerMeshRenderer.material.color = _MeshRenderer.material.color;
                foreach(IAbsorbable absorbable in _Absorbables){
                    absorbable.Absorb();
                }
                ComputeNewColor();
            }
        }
    }

    private void UpdateColorInfo(Color newColor)
    {
        _MeshRenderer.material.color = newColor;
    }

    private void UpdateDetectedColor(IAbsorbable[] absorbables)
    {
        _Absorbables = absorbables;
        ComputeNewColor();
    }

    private void ComputeNewColor()
    {
        Color endColor = new Color(0f, 0f, 0f, 0f);
        bool detected = false;
        foreach (var absorbable in _Absorbables)
        {
            var c = absorbable.GetColor();
            if (c == Color.grey) continue;
            if (c == Color.black)
            {
                endColor = Color.black;
                _PlayerPainter.SetColor(endColor);
                absorbable.Absorb();
                detected = false;
                break;
            }
            endColor += c;
            endColor.b = (endColor.b > 1f) ? 1f : endColor.b;
            endColor.b = (endColor.b < 0f) ? 0f : endColor.b;
            endColor.r = (endColor.r > 1f) ? 1f : endColor.r;
            endColor.g = (endColor.g > 1f) ? 1f : endColor.g;
            endColor.a = 1f;
            detected = true;
        }
        if (endColor.a == 0f)//Alpha to zero means no addition to a color; and so 
        {
            endColor = _PlayerMeshRenderer.material.color;
            detected = false;
        }
        UpdateColorInfo(endColor);
        _Animator.SetBool("ColorDetected", detected);//Run rotating animation
    }
}

//Color lexcial
// Black => Automatically set on the player when walking on it. But can't be set over another colorable area.
// Grey => Can't be absorb once set on colorable area.
// White => Stay white no mather what // TODO confirm.


// Other colors can be mixed up but that's for another story. 