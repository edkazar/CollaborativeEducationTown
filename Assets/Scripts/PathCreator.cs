using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Material pathMaterial;
    public float pathWidth = 0.2f;
    public Transform[] pathPoints; // Array of waypoints

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = pathWidth;
        lineRenderer.endWidth = pathWidth;

        // Set the initial positions of the Line Renderer
        lineRenderer.positionCount = pathPoints.Length;
        for (int i = 0; i < pathPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, pathPoints[i].position);
        }

        lineRenderer.material = pathMaterial;
    }
}
