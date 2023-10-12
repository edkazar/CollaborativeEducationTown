using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertObjectNormals : MonoBehaviour
{
    public GameObject DomeInside;

    void Awake()
    {
        InvertSphere();
    }

    void InvertSphere()
    {
        Vector3[] normals = DomeInside.GetComponent<MeshFilter>().mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }

        DomeInside.GetComponent<MeshFilter>().mesh.normals = normals;

        int[] triangles = DomeInside.GetComponent<MeshFilter>().mesh.triangles;
        for (int i = 0; i < triangles.Length; i+=3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }

        DomeInside.GetComponent<MeshFilter>().mesh.triangles = triangles;
    }

}
