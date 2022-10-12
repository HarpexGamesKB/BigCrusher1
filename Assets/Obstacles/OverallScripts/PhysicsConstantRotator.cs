using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PhysicsConstantRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _duration;
    [SerializeField] private float _delayBeforeStart;
    [SerializeField] private Ease _easeType = Ease.Linear;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        StartCoroutine(StartMoving(_delayBeforeStart));
    }

    private IEnumerator StartMoving(float delay)
    {
        yield return new WaitForSeconds(delay);

        _rigidBody.DORotate(_direction, _duration, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(_easeType);
    }
}
