using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform PlayerTransform;
    public Rigidbody PlayerRigidbody;
    public List<Vector3> VelocitiesList = new List<Vector3>();
    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            VelocitiesList.Add(transform.forward);
        }
    }
    private void FixedUpdate()
    {
        if (PlayerRigidbody.velocity.magnitude > 0.1f)
        {
            VelocitiesList.Add(PlayerRigidbody.velocity);
            VelocitiesList.RemoveAt(0);
        }
    }
    void Update()
    {
        Vector3 summ = transform.forward;
        for(int i = 0;i<VelocitiesList.Count;i++)
        {
            summ += VelocitiesList[i];
        }
        transform.position = PlayerTransform.position;
        transform.localScale = Vector3.Lerp(transform.localScale, PlayerTransform.localScale, 0.01f * Time.deltaTime);
        transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ),1f * Time.deltaTime);
        //transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ),2f);
    }
}
