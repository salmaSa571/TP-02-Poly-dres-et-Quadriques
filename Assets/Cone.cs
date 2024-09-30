using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Cone : MonoBehaviour




{
    public float rayonBase = 1f;    
    public float hauteur = 2f;       
    public int nbMeridiens = 20;     

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        CreerCone();
        MettreAJourMesh();
    }

    void CreerCone()
    {
        
        int nbVertices = nbMeridiens + 2; 
        vertices = new Vector3[nbVertices];

        
        float angleStep = 360f / nbMeridiens;
        for (int i = 0; i <= nbMeridiens; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            float x = Mathf.Cos(angle) * rayonBase;
            float z = Mathf.Sin(angle) * rayonBase;
            vertices[i] = new Vector3(x, 0, z);  
        }

        
        vertices[vertices.Length - 2] = new Vector3(0, 0, 0);          
        vertices[vertices.Length - 1] = new Vector3(0, hauteur, 0);    

        
        triangles = new int[nbMeridiens * 6]; 
        int tris = 0;

        
        for (int i = 0; i < nbMeridiens; i++)
        {
            triangles[tris + 0] = i;
            triangles[tris + 1] = (i + 1) % nbMeridiens;
            triangles[tris + 2] = vertices.Length - 2; 

            tris += 3;
        }

        
        for (int i = 0; i < nbMeridiens; i++)
        {
            triangles[tris + 0] = i;
            triangles[tris + 1] = (i + 1) % nbMeridiens;
            triangles[tris + 2] = vertices.Length - 1; 

            tris += 3;
        }
    }

    void MettreAJourMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
