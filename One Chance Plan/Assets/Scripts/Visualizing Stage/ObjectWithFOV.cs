using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithFOV : MonoBehaviour
{
    public void DrawMesh()
    {
        PolygonCollider2D collider = gameObject.GetComponentInChildren<PolygonCollider2D>();

        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = ToVector3(collider.points[0]);
        vertices[1] = ToVector3(collider.points[1]);
        vertices[2] = ToVector3(collider.points[2]);

        uv[0] = collider.points[0];
        uv[1] = collider.points[1];
        uv[2] = collider.points[2];

        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 2;

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        gameObject.GetComponentInChildren<MeshFilter>().mesh = mesh;

    }

    private Vector3 ToVector3(Vector2 vector)
    {
        return new Vector3()
        {
            x = vector.x,
            y = vector.y,
            z = 0f
        };
    }
}
