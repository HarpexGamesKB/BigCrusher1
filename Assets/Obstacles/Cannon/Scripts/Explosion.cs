using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _mainRadius = 4;
    [SerializeField] private float _secondRadius = 7.5f;
    [SerializeField] private float _power;

    public void Explode()
    {
        //AddForceAtRadius(_secondRadius, _power / 7);
        AddForceAtRadius(_mainRadius, _power);
    }

    private void AddForceAtRadius(float radius, float power)
    {/*
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out ObstacleCollision obstacleCollision))
            {
                obstacleCollision.FallingBank(transform.position);
            }

            Transform parent = TransformExtension.GetParentWithTag(hitCollider.transform);

            if (parent.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.velocity = Vector3.zero;

                Vector3 direction = rigidbody.transform.position - transform.position;
                direction = direction.normalized;

                rigidbody.AddForce(direction * power, ForceMode.VelocityChange);
                rigidbody.AddForce(Vector3.up * power, ForceMode.VelocityChange);
            }
        }*/
    }
}