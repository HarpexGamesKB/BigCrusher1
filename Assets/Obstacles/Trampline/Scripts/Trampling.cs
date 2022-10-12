using System;
using UnityEngine;

public class Trampling : MonoBehaviour
{
    public Vector3 direction;
    public float power = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + direction * 10); // ray for direction vision
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * power); // ray for power vision
    }
}