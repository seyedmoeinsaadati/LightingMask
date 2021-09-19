using UnityEngine;

public class CircleFace
{
    Mesh mesh;
    int resolution;
    Vector3 centerPos, firstPoint, direction;
    float radius;

    public CircleFace(Mesh mesh, int resolution, Vector3 centerPos, Vector3 diirection, float radius)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.centerPos = Vector3.zero;
        this.direction = diirection;
        this.radius = radius;
    }

    public void BuildMesh()
    {
        this.firstPoint = centerPos + direction;

        Vector3[] vertices = new Vector3[resolution + 1];
        int[] triangles = new int[resolution * 3];

        vertices[0] = centerPos;
        vertices[1] = firstPoint * radius;

        for (int i = 2; i < vertices.Length; i++)
        {
            Vector3 rotatePoint = Rotate(vertices[i - 1], 360 / resolution * Mathf.Deg2Rad, true);
            vertices[i] = rotatePoint;
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