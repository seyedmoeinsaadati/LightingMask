using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public bool autoUpdate;
    public MeshFilter meshFilter;

    [Range(3, 100)]
    public int resolution;

    [Range(0.1f, 180)]
    public float radius;

    CircleFace circleFace;

    public void GenerateMesh(int resolution, float radius)
    {
        circleFace = new CircleFace(meshFilter.sharedMesh, resolution, Vector3.up, radius);
        circleFace.BuildMesh();
    }

    private void OnValidate()
    {
        if (autoUpdate)
        {
            GenerateMesh(resolution, radius);
        }
    }
}

