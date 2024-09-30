using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDePlan : MonoBehaviour
{
    public int nombre_Lignes = 10;  // Nombre de lignes du plan
    public int nb_Colonnes = 10;    // Nombre de colonnes du plan
    public float taille = 1.0f;     // Taille de chaque cellule du plan

    void Start()
    {
        // Ajouter un composant MeshFilter et MeshRenderer à l'objet
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Créer un nouveau Mesh
        Mesh mesh = new Mesh();

        // Définir les sommets du plan
        Vector3[] vertices = new Vector3[(nombre_Lignes + 1) * (nb_Colonnes + 1)];
        for (int i = 0, z = 0; z <= nombre_Lignes; z++)
        {
            for (int x = 0; x <= nb_Colonnes; x++, i++)
            {
                vertices[i] = new Vector3(x * taille, 0, z * taille);
            }
        }

        // Définir les triangles à partir des sommets
        int[] triangles = new int[nombre_Lignes * nb_Colonnes * 6];
        for (int ti = 0, vi = 0, z = 0; z < nombre_Lignes; z++, vi++)
        {
            for (int x = 0; x < nb_Colonnes; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 1] = vi + nb_Colonnes + 1;
                triangles[ti + 2] = vi + 1;
                triangles[ti + 3] = vi + 1;
                triangles[ti + 4] = vi + nb_Colonnes + 1;
                triangles[ti + 5] = vi + nb_Colonnes + 2;
            }
        }

        // Assigner les sommets et les triangles au Mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        // Attribuer le Mesh à l'objet
        meshFilter.mesh = mesh;

        // Ajouter un matériau standard
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}
