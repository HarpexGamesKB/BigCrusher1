using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _shootDelay = 3;
    [SerializeField] private float _delayBeforeStart = 0;
    [SerializeField] private Transform _model;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _upLeftFieldPoint;
    [SerializeField] private Transform _downRightFieldPoint;
    [SerializeField] private ParabolaMover _prefab;

    public Vector3 UpLeftFieldPosition { get => _upLeftFieldPoint.transform.position; }
    public Vector3 DownRightFieldPosition { get => _downRightFieldPoint.transform.position; }

    public UnityEvent Shooted;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_delayBeforeStart);

        while (true)
        {
            yield return new WaitForSeconds(_shootDelay / 2);

            Vector3 shootPosition = CalculateShootPosition();

            Vector3 lookTarget = shootPosition;
            lookTarget.y = transform.position.y;
            _model.DOLookAt(lookTarget, _shootDelay / 2);

            yield return new WaitForSeconds(_shootDelay / 2);
            
            Shoot(shootPosition);
        }
    }

    private void Shoot(Vector3 shootPosition)
    {
        Shooted?.Invoke();
        ParabolaMover bullet = Instantiate(_prefab, _shootPoint.transform.position, Quaternion.identity, transform);
        bullet.Init(_shootPoint.transform.position, shootPosition);
    }

    private Vector3 CalculateShootPosition()
    {
        Vector3 targetPosition = new Vector3();

        targetPosition.x = Random.Range(UpLeftFieldPosition.x, DownRightFieldPosition.x);
        targetPosition.y = Random.Range(UpLeftFieldPosition.y, DownRightFieldPosition.y);
        targetPosition.z = Random.Range(UpLeftFieldPosition.z, DownRightFieldPosition.z);

        return targetPosition;
    }
}
