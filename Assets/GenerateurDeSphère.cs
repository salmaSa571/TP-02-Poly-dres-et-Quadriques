using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeSphère : MonoBehaviour
{
    public float rayon = 1.0f;             
    public int nombre_Meridiens = 20;      
    public int nombre_Paralleles = 10;     

    void Start()
    {
        GenererSphère();
    }

    void GenererSphère()
    {
        
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        
        Mesh mesh = new Mesh();

        
        Vector3[] vertices = new Vector3[(nombre_Meridiens + 1) * (nombre_Paralleles + 1)];
        for (int i = 0; i <= nombre_Paralleles; i++)
        {
            float latitude = Mathf.PI * (-0.5f + (float)i / nombre_Paralleles); 
            for (int j = 0; j <= nombre_Meridiens; j++)
            {
                float longitude = 2 * Mathf.PI * (float)j / nombre_Meridiens; 
                float x = rayon * Mathf.Cos(latitude) * Mathf.Cos(longitude);
                float y = rayon * Mathf.Sin(latitude);
                float z = rayon * Mathf.Cos(latitude) * Mathf.Sin(longitude);
                vertices[i * (nombre_Meridiens + 1) + j] = new Vector3(x, y, z);
            }
        }

        
        int[] triangles = new int[nombre_Meridiens * nombre_Paralleles * 6];
        int t = 0;
        for (int i = 0; i < nombre_Paralleles; i++)
        {
            for (int j = 0; j < nombre_Meridiens; j++)
            {
                int vert1 = i * (nombre_Meridiens + 1) + j;
                int vert2 = vert1 + nombre_Meridiens + 1;

                
                triangles[t++] = vert1;
                triangles[t++] = vert2;
                triangles[t++] = vert1 + 1;

                
                triangles[t++] = vert2;
                triangles[t++] = vert2 + 1;
                triangles[t++] = vert1 + 1;
            }
        }

        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        
        meshFilter.mesh = mesh;
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}
