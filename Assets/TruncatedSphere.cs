using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruncatedSphere : MonoBehaviour
{
    public int meridiens = 20;       
    public int paralleles = 10;      
    public float rayon = 1f;         
    public float angleTronque = 45f; 

    void Start()
    {
        
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        
        CreateTruncatedSphere(mesh);
    }

    void CreateTruncatedSphere(Mesh mesh)
    {
        
        float angleTronqueRad = Mathf.Deg2Rad * angleTronque;

        
        Vector3[] vertices = new Vector3[(meridiens + 1) * (paralleles + 1)];
        int[] triangles = new int[meridiens * paralleles * 6];

        
        for (int i = 0; i <= paralleles; i++)
        {
            
            float theta = Mathf.PI * i / paralleles;
            for (int j = 0; j <= meridiens; j++)
            {
                
                float phi = 2 * Mathf.PI * j / meridiens;

                
                if (phi <= angleTronqueRad || phi >= (2 * Mathf.PI - angleTronqueRad))
                    continue;

                
                float x = rayon * Mathf.Sin(theta) * Mathf.Cos(phi);
                float y = rayon * Mathf.Cos(theta);
                float z = rayon * Mathf.Sin(theta) * Mathf.Sin(phi);

                vertices[i * (meridiens + 1) + j] = new Vector3(x, y, z);
            }
        }

        
        int triIndex = 0;
        for (int i = 0; i < paralleles; i++)
        {
            for (int j = 0; j < meridiens; j++)
            {
                if ((j * 2 * Mathf.PI / meridiens) <= angleTronqueRad || (j * 2 * Mathf.PI / meridiens) >= (2 * Mathf.PI - angleTronqueRad))
                    continue;

                int current = i * (meridiens + 1) + j;
                int next = current + meridiens + 1;

                
                triangles[triIndex] = current;
                triangles[triIndex + 1] = next;
                triangles[triIndex + 2] = current + 1;

                
                triangles[triIndex + 3] = current + 1;
                triangles[triIndex + 4] = next;
                triangles[triIndex + 5] = next + 1;

                triIndex += 6;
            }
        }

        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
