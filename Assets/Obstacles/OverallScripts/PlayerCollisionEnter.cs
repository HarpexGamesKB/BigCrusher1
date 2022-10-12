using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionEnter : MonoBehaviour
{
    public UnityEvent<Transform> CollisionEnter;
    public UnityEvent<Transform> CollisionExit;

    private void OnCollisionEnter(Collision other) 
    {
        /*
        Transform parent = TransformExtension.GetParentWithTag(other.transform);

        if (parent.TryGetComponent(out PlayerRacer racer))
        {
            CollisionEnter?.Invoke(parent);
        }*/
    }

    private void OnCollisionExit(Collision other) 
    {/*
        Transform parent = TransformExtension.GetParentWithTag(other.transform);

        if (parent.TryGetComponent(out PlayerRacer racer))
        {
            CollisionExit?.Invoke(parent);
        }*/
    }
}
