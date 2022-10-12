using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private Collider Collider;
    public Rigidbody Rigidbody;
    public bool isCollected;
    public EnemyMove EnemyMove;
    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void Collect()
    {
        isCollected = true;
        Collider.enabled = false;
        Rigidbody.isKinematic = true;
        
    }
    public void BeCollectable()
    {
        transform.SetParent(null);
        Rigidbody.isKinematic = false;
        Collider.enabled = true;
        MakeItCollectable();
    }
    public void Die()
    {Destroy(gameObject);
    }
    public void OnLoseSomeMass()
    {
        if (gameObject == null) return;
        BeCollectable();
        if (EnemyMove != null)
        {
            EnemyMove.Collectables.Remove(this);
        }
        
    }
    public void MakeItCollectable()
    {
        StartCoroutine(nameof(BeCollectableAfter));
    }
    public IEnumerator BeCollectableAfter()
    {
        yield return new WaitForSeconds(1f);
        isCollected = false;
    }
    public void OnCollectedByPlayer()
    {
        Collect();

    }
    public void OnCollectedByEnemy()
    {
        Collect();
        
    }
}
