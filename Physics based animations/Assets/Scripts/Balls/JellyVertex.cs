using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thiis call is to hold all the vertex information

public class JellyVertex
{
    public int verticeIndex;
    public Vector3 initialVertexPosition;
    public Vector3 currentVertexPosition;

    public Vector3 currentVelocity;

    //Contructor
    public JellyVertex(int _verticeIndex, Vector3 _initialVertexPosition, Vector3 _currentVertexPosition, Vector3 _currentVelocity)
    {
        verticeIndex = _verticeIndex;
        initialVertexPosition = _initialVertexPosition;
        currentVertexPosition = _currentVertexPosition;
        currentVelocity = _currentVelocity;
    }

    //Funciton to caculate the displacement vector between the current vertex position and the initial one
    public Vector3 GetCurrentDisplacement()
    {
        return currentVertexPosition - initialVertexPosition;
    }

    //Function to calculate and update the velocity for each vertex while deformation
    public void UpdateVelocity(float _bounceSpeed)
    {
        currentVelocity = currentVelocity - GetCurrentDisplacement() * _bounceSpeed * Time.deltaTime;
    }

    //Function to stop jiggering over time, not for ethernity which matters of the stiffness attribute of the object
    public void Settle(float _stiffness)
    {
        // make the velocity return to 0 over time
        currentVelocity *= 1f - _stiffness * Time.deltaTime; // multiply the current velocity by 1 - stiffness * delta time
    }

    //Function to apply pressure to the vertices
    public void ApplyPressureToVertex(Transform _tranform, Vector3 _position, float _pressure)
    {
        // get the distance from a vertex to the input position (where the mesh was touched)
        Vector3 distanceVerticePoint = currentVertexPosition - _tranform.InverseTransformPoint(_position);

        // use that distance to calculate the adapted pressure that will turn into a new velocity
        float adaptPressure = _pressure / (1f + distanceVerticePoint.sqrMagnitude);
        float velocity = adaptPressure * Time.deltaTime;
        currentVelocity += distanceVerticePoint.normalized * velocity; // use the point where the mesh was touched, normalized value get the right direction for the new velocity
    }
}



