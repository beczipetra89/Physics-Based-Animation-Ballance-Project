// Attach this script to the game object to jellyfy it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfier : MonoBehaviour
{
    public float bounceSpeed; // jiggling speed of back and forth
    public float fallForce; // emulate mass when drop the object
    public float stiffness; 

    // Access mesh of the game object since we want to apply soft body physics on the mesh (on vertices), mesh deformation
    private MeshFilter meshFilter;
    private Mesh mesh;

    // create a list of vertices and the current vertices
    JellyVertex[] jellyVertices;
    Vector3[] currentMeshVertices;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        GetVertices();
    }

    private void Update()
    {
        UpdateVertices(); //update deformations in each update loop
    }

    private void GetVertices()
    //Function to get the all the vertices of the mesh and store them into the list
    {
        jellyVertices = new JellyVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            jellyVertices[i] = new JellyVertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }

    private void UpdateVertices()
    //Function to go over every single vertices and update it and applied it to the mesh for observable the deformation
    {
        for (int i = 0; i < jellyVertices.Length; i++)
        {
            // Call the calculating functions from JellyVertex class for the proper deformation of this object´s mesh (on vertices)
            jellyVertices[i].UpdateVelocity(bounceSpeed); 
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].currentVertexPosition += jellyVertices[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = jellyVertices[i].currentVertexPosition;
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    public void OnCollisionEnter(Collision other)
    // Collision check using points we want the vertices to deform where they were touched (at the input point)
    {
        //loop through every contact point
        ContactPoint[] collisionPoints = other.contacts;
        for(int i = 0; i < collisionPoints.Length; i++)
        {
            Vector3 inputPoint = collisionPoints[i].point + (collisionPoints[i].point * .1f); //apply offset to the contact point
            ApplyPressureToPoint(inputPoint, fallForce); // apply the pressure to the mesh on the set point
        }
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure)
    {
        for(int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].ApplyPressureToVertex(transform, _point, _pressure); //call the ApplyPressureToVertex function from JellyVertex
        }
    }


}
