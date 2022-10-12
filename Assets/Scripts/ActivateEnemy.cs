using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public EnemyMove enemyMove;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (player)
        {
            enemyMove.StartMove();
            return;
            //SnowManager.CollectSnow(other.GetComponent<Snow>());
            //AudioSource.pitch = Random.Range(0.8f, 1.2f);
            //AudioSource.Play();
        }
    }
}
