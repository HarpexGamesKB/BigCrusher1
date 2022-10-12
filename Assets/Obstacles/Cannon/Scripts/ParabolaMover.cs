using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParabolaMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private bool _throw;
    private float anim;
    private Vector3 _startPos;
    private Vector3 _throwPos;

    public UnityEvent<Vector3> MovingStarted;
    public UnityEvent MovingFinished;
    public Vector3 ThrowPos { get => _throwPos; }

    public void Init(Vector3 startPos, Vector3 endPos)
    {
        MovingStarted?.Invoke(endPos);
        _startPos = startPos;
        _throwPos = endPos;
        anim = 0;
        _throw = true;
    }

    private void Update()
    {
        if (_throw)
        {
            if (Vector3.Distance(transform.position, _throwPos) < 1f)
            {
                _throw = false;
                MovingFinished?.Invoke();
            }
            else
            {
                anim += _speed * Time.deltaTime;
                transform.position = MathParabola.Parabola(_startPos, _throwPos, 6f, anim);
            }
        }
    }

}
