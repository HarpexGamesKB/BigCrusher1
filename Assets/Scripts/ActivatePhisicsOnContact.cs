using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePhisicsOnContact : MonoBehaviour
{
    private CollectableItem[] AllCubes;
    private Collider Collider;
    void Start()
    {
        Collider = GetComponent<Collider>();
        AllCubes = GetComponentsInChildren<CollectableItem>();
    }
    public void ActivatePhysics()
    {
        Collider.enabled = false;
        foreach (CollectableItem item in AllCubes)
        {
            if (item.transform.parent != transform) continue;
            item.Rigidbody.isKinematic = false;
        }
    }
}
