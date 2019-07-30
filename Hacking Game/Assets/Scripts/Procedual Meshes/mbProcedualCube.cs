using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class mbProcedualCube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    public float scale = 1f;
    public int posX, posY, posZ;


    float adjScale;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        adjScale = scale * 0.5f;
    }

    private void Start()
    {
        // Runs the MakeCube Method and feeding the arguments of the adjusted Scale and the
        //position data multiplied with the scale so it is positioned independendly from its object scale
        MakeCube(adjScale, new Vector3((float)posX * scale, (float)posY * scale, (float)posZ * scale));
        CreateMesh();
    }

    void MakeCube(float cubeScale, Vector3 cubePos)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        // Iterates through 6 sides of the cube
        for (int i = 0; i < 6; i++)
        {
            // The increment i is driving the direction of the cube's face 
            MakeFace(i, cubeScale, cubePos);
        }
    }

    // Method that makes the one quadface depending of its given direction
    void MakeFace(int dir, float faceScale, Vector3 facePos)
    {
        vertices.AddRange(sCubeMeshData.faceVertices(dir, faceScale, facePos));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);

    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
    }
}
