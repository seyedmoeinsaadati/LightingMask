using System;
using UnityEngine;

public class CircleFace
{
    Mesh mesh;
    int resolution;
    Vector3 direction;
    float radius;

    public CircleFace()
    {
    }

    public CircleFace(Mesh mesh, int resolution, Vector3 direction, float radius)
    {
        Init(mesh, resolution, direction, radius);
    }

    public void Init(Mesh mesh, int resolution, Vector3 direction, float radius)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.direction = direction;
        this.radius = radius;
    }

    public void RefreshMesh()
    {
        Vector3[] vertices = new Vector3[resolution + 1];
        int[] triangles = new int[resolution * 3];

        vertices[0] = Vector3.zero;
        vertices[1] = direction * radius;

        // calculating vertices
        for (int i = 2; i < vertices.Length; i++)
        {
            Vector3 rotatePoint = vertices[i - 1].RotateXY((float)360 / resolution * Mathf.Deg2Rad, true);
            vertices[i] = rotatePoint;
        }

        // calculating triangles
        int triangleIndex = 0;
        for (int i = 0; i < vertices.Length - 1; i++)
        {
            triangles[triangleIndex] = 0;
            triangles[triangleIndex + 1] = i + 1;
            triangles[triangleIndex + 2] = (i == vertices.Length - 2) ? 1 : i + 2;
            triangleIndex += 3;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}