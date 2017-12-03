using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInfoScript : MonoBehaviour
{
    public GameObject ColorChecker;
    private MeshRenderer _MeshRenderer;
    private MeshRenderer _PlayerMeshRenderer;
    private MeshRenderer _CurrentDetectedColor;
    private Animator _Animator;
    private PainterScript _PlayerPainter;

    // Use this for initialization
    private void Start()
    {
        _MeshRenderer = GetComponent<MeshRenderer>();
        _Animator = GetComponent<Animator>();
        _PlayerMeshRenderer = transform.parent.gameObject.GetComponent<MeshRenderer>();

        _PlayerPainter = GetComponentInParent<PainterScript>();

        _PlayerPainter.OnColorChanged += UpdateColorInfo;
        ColorChecker.GetComponent<ColorAbsorberScript>().OnColorDetected += UpdateDetectedColor;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((_MeshRenderer.material.color != _PlayerMeshRenderer.material.color))
        {
            //Maybe do something different if we are black or consider it's a death color.
            if (_CurrentDetectedColor != null && Input.GetButtonDown("ColorSwap")) // Swap Colors
            {
                if (_PlayerMeshRenderer.material.color != Color.black)
                    _CurrentDetectedColor.material.color = _PlayerPainter.GetColor();
                _PlayerPainter.SetColor(_MeshRenderer.material.color);
                UpdateColorInfo(_CurrentDetectedColor.material.color);
            }
        }
    }

    private void UpdateColorInfo(Color newColor)
    {
        _MeshRenderer.material.color = newColor;
    }

    private void UpdateDetectedColor(MeshRenderer renderer)
    {
        _CurrentDetectedColor = renderer;
        if(_CurrentDetectedColor == null)
        {
            _MeshRenderer.material.color = _PlayerMeshRenderer.material.color;
            _Animator.SetBool("ColorDetected", false);
        }
        else
        {
            UpdateColorInfo(_CurrentDetectedColor.material.color);
            if (_CurrentDetectedColor.material.color == Color.black)
            {
                _PlayerPainter.SetColor(_CurrentDetectedColor.material.color);
                _Animator.SetBool("ColorDetected", false);
                return;
            }
            _Animator.SetBool("ColorDetected", true);//Run rotating animation
        }
    }
}

//Color lexcial
// Black => Automatically set on the player when walking on it. But can't be set over another colorable area.
// Grey => Can't be absorb once set on colorable area.
// White => Stay white no mather what // TODO confirm.


// Other colors can be mixed up but that's for another story. 