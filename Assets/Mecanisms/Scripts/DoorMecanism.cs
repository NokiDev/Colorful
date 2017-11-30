using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMecanism : MecanismBase
{
    // Use this for initialization
    private void Start()
    {
        OnActivation = Open;
        OnDeactivation = Close;
    }

    private void Open()
    {
        GetComponent<Animator>().SetBool("Open", true);
    }

    private void Close()
    {
        GetComponent<Animator>().SetBool("Open", false);
    }
}