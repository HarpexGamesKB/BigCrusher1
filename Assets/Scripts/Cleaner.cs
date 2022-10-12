using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectableItem item = other.GetComponent<CollectableItem>();
        if (item)
        {
            item.Die();
        }


        Player player = other.GetComponentInParent<Player>();
        if (player)
        {
            LevelManager.Instance.Restart();
        }
    }
}
