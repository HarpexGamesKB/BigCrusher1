using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform CameraCenter;
    public float TorqueValue;

    public DynamicJoystick DynamicJoystick;
    public FixedJoystick FixedJoystick;
    private void Start()
    {
        _rigidbody=GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500;
    }
    void FixedUpdate()
    {
        _rigidbody.AddTorque(CameraCenter.right * TorqueValue * FixedJoystick.Vertical, ForceMode.Acceleration);
        _rigidbody.AddTorque(-CameraCenter.forward * TorqueValue * FixedJoystick.Horizontal, ForceMode.Acceleration);
    }
}
