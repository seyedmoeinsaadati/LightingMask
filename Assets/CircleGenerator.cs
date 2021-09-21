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

    private void Awake()
    {
        circleFace = new CircleFace();
    }

    public void GenerateMesh(int resolution, float radius)
    {
        if (circleFace == null)
            circleFace = new CircleFace();

        circleFace.Init(meshFilter.sharedMesh, resolution, Vector3.up, radius);
        circleFace.RefreshMesh();
    }

    private void OnValidate()
    {
        if (autoUpdate)
        {
            GenerateMesh(resolution, radius);
        }
    }
}

