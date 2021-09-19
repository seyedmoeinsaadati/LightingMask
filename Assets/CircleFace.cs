using UnityEngine;

public class CircleFace
{
    Mesh mesh;
    int resolution;
    Vector3 direction;
    float radius;

    public CircleFace(Mesh mesh, int resolution, Vector3 direction, float radius)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.direction = direction;
        this.radius = radius;
    }

    public void BuildMesh()
    {
        Vector3[] vertices = new Vector3[resolution + 1];
        int[] triangles = new int[resolution * 3];

        vertices[0] = Vector3.zero;
        vertices[1] = direction * radius;

        for (int i = 2; i < vertices.Length; i++)
        {
            Vector3 rotatePoint = Rotate(vertices[i - 1], 360 / resolution * Mathf.Deg2Rad, true);
            vertices[i] = rotatePoint;

            // if (i > 1)
            // {
            //     var j = (i - 2) * 3;
            //     triangles[j + 0] = 0;
            //     triangles[j + 1] = i - 1;
            //     triangles[j + 2] = i;
            // }
        }

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

    public static Vector3 Rotate(Vector3 vector, float angle, bool clockwise) //in radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Vector3(xVal, yVal, 0);
    }

}