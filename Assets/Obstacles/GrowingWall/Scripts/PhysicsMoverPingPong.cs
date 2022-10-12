using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PhysicsMoverPingPong : MonoBehaviour
{
    [SerializeField] private Vector3 _to;
    [SerializeField] private float _duration;
    [SerializeField] private float _delayBeforeStart;
    [SerializeField] private float _delayBetwenMoves;
    [SerializeField] private Ease _easeType;

    //private Rigidbody _rigidBody;
    private Vector3 _from;

    private void Start()
    {
        //_rigidBody = GetComponent<Rigidbody>();
        _from = transform.position;

        StartCoroutine(StartMoving(_delayBeforeStart));
    }

    private IEnumerator StartMoving(float delay)
    {
        yield return new WaitForSeconds(delay);

        StartCoroutine(Moving(_from, _from + _to, _delayBetwenMoves));
    }

    private IEnumerator Moving(Vector3 startPosition, Vector3 moveToPosition, float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMove(moveToPosition, _duration).SetEase(_easeType);
        //_rigidBody.DOMove(moveToPosition, _duration).SetEase(_easeType);

        yield return new WaitForSeconds(_duration);
        StartCoroutine(Moving(moveToPosition, startPosition, _delayBetwenMoves));
    }
}
