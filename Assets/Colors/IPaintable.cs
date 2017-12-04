using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPaintable
{ 
    void Paint(Color newColor);
    Color GetColor();
}
