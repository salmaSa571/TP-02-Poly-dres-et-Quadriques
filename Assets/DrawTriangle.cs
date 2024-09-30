using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTriangle : MonoBehaviour
{
    
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),  // Sommet A
            new Vector3(1, 0, 0),  // Sommet B
            new Vector3(0, 1, 0)   // Sommet C
        };

        
        int[] triangles = new int[]
        {
            0, 1, 2
        };

        
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        
        mesh.RecalculateNormals();

        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}
