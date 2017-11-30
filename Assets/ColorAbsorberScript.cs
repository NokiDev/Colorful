using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAbsorberScript : MonoBehaviour
{
    public delegate void ColorObserver(MeshRenderer colorableObject);

    public ColorObserver OnColorDetected;

    // Use this for initialization
    private void Start()
    {
        OnColorDetected += colorObject => { Debug.Log(colorObject); };
    }

    private void OnTriggerEnter(Collider c)
    {
        DetectColor();
    }

    private void OnTriggerStay(Collider c)
    {
        DetectColor();
    }

    private void OnTriggerExit(Collider c)
    {
        /*if (!DetectColor())
        {
        }*/
        OnColorDetected(null);
    }

    private bool DetectColor()
    {
        var hit = new RaycastHit();
        if (Physics.Raycast(transform.parent.transform.position, -transform.up, out hit, Mathf.Infinity, 1 << 10))
        {
            var renderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
            if(renderer.material.color != Color.grey)// Don't detect Grey color;
            {
                Debug.Log(Color.grey);
                Debug.Log("Detected Color : " + renderer.material.color);
                OnColorDetected(renderer);
            }
            else
            {
                OnColorDetected(null);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}