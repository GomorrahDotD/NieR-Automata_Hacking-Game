using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class mbProcedualMesh : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangels;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    void MakeMeshData()
    {
        // Vertices
        vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1) };

        // Triangles
        triangels = new int[] { 0, 1, 2, 2, 1, 3 };
    }
    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangels;

        mesh.RecalculateNormals();
    }
}
