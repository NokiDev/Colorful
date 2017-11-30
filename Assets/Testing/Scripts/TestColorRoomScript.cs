using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorRoomScript : MonoBehaviour
{
    public GameObject reference;
    public Color[,] colors = new Color[5, 5];
    private List<GameObject> colorCubes = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        var size = reference.GetComponent<MeshRenderer>().bounds.size;
        colors[0, 0] = Color.white;
        colors[0, 1] = Color.black;
        colors[0, 2] = Color.grey;
        colors[0, 3] = Color.gray;
        colors[0, 4] = Color.blue;

        colors[1, 0] = Color.yellow;
        colors[1, 1] = Color.cyan;
        colors[1, 2] = Color.magenta;
        colors[1, 3] = Color.red;
        colors[1, 4] = Color.blue;

        colors[2, 0] = Color.green;
        colors[2, 1] = Color.white;
        colors[2, 2] = Color.white;
        colors[2, 3] = Color.white;
        colors[2, 4] = Color.white;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                var go = Instantiate(reference, this.transform);
                go.GetComponent<Transform>().localPosition = new Vector3(i * size.x, 0, j * size.z);
                go.GetComponent<MeshRenderer>().material.color = colors[i, j];
                colorCubes.Add(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}