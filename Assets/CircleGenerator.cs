using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public bool autoUpdate;
    public MeshFilter meshFilter;
    [Range(3, 100)]
    public int resolution;
    
    [Range(1, 180)]
    public float radius;

    CircleFace circleFace;

    private void Init()
    {
        circleFace = new CircleFace(meshFilter.sharedMesh, resolution, meshFilter.transform.position, Vector3.up, radius);
    }

    public void GenerateMesh()
    {
        circleFace.BuildMesh();
    }

    private void OnValidate()
    {
        if (autoUpdate)
        {
            Init();
            GenerateMesh();
        }
    }
}

