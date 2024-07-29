using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenRay : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    public List<Vector2> linepoints = new List<Vector2>();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        linepoints[0] = lineRenderer.GetPosition(0);
        linepoints[1] = lineRenderer.GetPosition(1);

        edgeCollider.SetPoints(linepoints);
    }
}
