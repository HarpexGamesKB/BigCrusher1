using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCenter : MonoBehaviour
{
    public Transform PlayerTransform;
    
    void Update()
    {
        if (PlayerTransform == null) return;
        transform.position = PlayerTransform.position;
    }
}
