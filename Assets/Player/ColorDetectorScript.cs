using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetectorScript : MonoBehaviour
{
    public delegate void PaintableObserver(IPaintable[] colorableObject);
    public delegate void AbsorbableObserver(IAbsorbable[] colorableObject);
    public AbsorbableObserver OnAbsorbablesChanged;
    public PaintableObserver OnPaintableChanged;

    List<IPaintable> _Paintables = new List<IPaintable>();
    List<IAbsorbable> _Absorbables = new List<IAbsorbable>();

    // Use this for initialization
    private void Start()
    {
        OnPaintableChanged += colorObject => { };
        OnAbsorbablesChanged += colorObject => { };
    }

    private void OnTriggerEnter(Collider c)
    {
        Add(c.gameObject);
    }

    private void OnTriggerExit(Collider c)
    {
        Remove(c.gameObject);
    }

    private void Remove(GameObject go)
    {
        var paintable = go.GetComponent<PaintableBase>();
        var absorbable = go.GetComponent<AbsorbableBase>();
        if (paintable)
        {
            _Paintables.Remove(paintable);
            OnPaintableChanged(_Paintables.ToArray());
        }
        if (absorbable)
        {
            _Absorbables.Remove(absorbable);
            OnAbsorbablesChanged(_Absorbables.ToArray());
        }
    }
    private bool Add(GameObject go)
    {
        var paintable = go.GetComponent<PaintableBase>();
        var absorbable = go.GetComponent<AbsorbableBase>();
        var ret = false;
        if (paintable)
        {
            _Paintables.Add(paintable);
            OnPaintableChanged(_Paintables.ToArray());
            ret = true;
        }
        if (absorbable && absorbable.GetColor() != Color.grey)
        {
            _Absorbables.Add(absorbable);
            OnAbsorbablesChanged(_Absorbables.ToArray());
            ret = true;
        }

        return ret;
    }
}