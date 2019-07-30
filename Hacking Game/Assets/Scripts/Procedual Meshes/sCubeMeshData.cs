using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class sCubeMeshData
{
    // Data of unit coordinates
    public static Vector3[] vertices =
    {
        new Vector3( 1,  1,  1),
        new Vector3(-1,  1,  1),
        new Vector3(-1, -1,  1),
        new Vector3( 1, -1,  1),
        new Vector3(-1,  1, -1),
        new Vector3( 1,  1, -1),
        new Vector3( 1, -1, -1),
        new Vector3(-1, -1, -1),
    };

    // Information of witch vertices make up a face
    public static int[][] faceTriangles =
    {   
        // North
        new int[]{0, 1, 2, 3},
        // East
        new int[]{5, 0, 3, 6},
        // South
        new int[]{4, 5, 6, 7},
        // West
        new int[]{1, 4, 7, 2},
        // Up
        new int[]{5, 4, 1, 0},
        // Down
        new int[]{3, 2, 7, 6},
    };

    // Method returns a Vector3 array which contains the information of 4 
    //that make up a quadface given by the direction it is facing (e.g North)
    //Also it multiplies the data of the vertices with the given scale and
    // offsets them by a given position vector
    public static Vector3[] faceVertices(int dir, float scale, Vector3 pos)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            fv [i] = (vertices[faceTriangles [dir] [i]] * scale) + pos;
        }
        return fv;
    }
}
