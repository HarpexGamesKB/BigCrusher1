using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public Transform Center;
    public Transform Target;
    public float TorqueValue;

    public float Radius = 10f;
    public bool invulrable;
    public bool CanMove = false;
    //[SerializeField] private Animator _animator;

    public List<CollectableItem> Collectables = new List<CollectableItem>();
    public List<CollectableItem> CanBeCollected;
    public Enemy Enemy;
    //[SerializeField] private float _speed = 10f;
    //[SerializeField] private float _maxSpeed = 7f;
    //public Transform Target;
    //public float RotationSpeed = 5f;
    public void OnCollect(CollectableItem collectable)
    {
        Collectables.Add(collectable);
        CanBeCollected.Remove(collectable);
    }
    
    public void StartMove()
    {
        CanMove = true;
        // _animator.SetBool("StartMove", true);
    }
    public void StopMove()
    {
        CanMove = false;
        //_animator.SetBool("StartMove", false);
    }
    public void GetCollectableListInRadius()
    {
        CanBeCollected.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
        foreach (Collider collider in colliders)
        {
            CollectableItem collectable = collider.GetComponent<CollectableItem>();
            if (collectable)
            {
                if (collectable.isCollected == false)
                {
                    CanBeCollected.Add(collectable);
                    collectable.EnemyMove = this;
                }
            }
        }
        Invoke(nameof(GetCollectableListInRadius), 7f);
    }
    public void LoseSomeMass()
    {
        if (invulrable) return;
        //חלוםרטעט
        //ÿךשמ חאלאכמ עמ גלונעט
        invulrable = true;
        Enemy.TakeDamage(1);
        for (int i = 0;
            i < (Enemy.Health >= 0 ? Collectables.Count * 0.7f : Collectables.Count);
            i++)
        {
            int randomint = Random.Range(0, Collectables.Count);
            Collectables[randomint].OnLoseSomeMass();
            ResetInvulrable();
        }
    }
    public void ResetInvulrable()
    {
        StartCoroutine(nameof(ResetInvulrableAfter));
    }
    public IEnumerator ResetInvulrableAfter()
    {
        yield return new WaitForSeconds(2f);
        invulrable = false;
    }
    private void FindClosestItem()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (CanBeCollected.Count < 1) return;
        for (int i = 0; i < CanBeCollected.Count; i++)
        {
            if (CanBeCollected[i] == null)
            {
                CanBeCollected.Remove(CanBeCollected[i]);
            }
            Vector3 diff = CanBeCollected[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                Target = CanBeCollected[i].transform;
                distance = curDistance;
            }
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500;
        GetCollectableListInRadius();
        FindClosestItem();
        //Target = CanBeCollected[Random.Range(0, CanBeCollected.Count)].transform;
        //_animator.speed = Random.Range(0.6f, 1.4f);
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        if (!CanMove) return;
        FindClosestItem();

        Vector3 direction = (Center.position - Target.position).normalized;
        Center.rotation = Quaternion.Lerp(Center.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * 8);
        //_rigidbody.AddTorque((-direction) *  TorqueValue * Time.deltaTime, ForceMode.Acceleration);


        _rigidbody.AddForce(Time.deltaTime * TorqueValue * -direction, ForceMode.VelocityChange);



        //if (_canMove)
        //{



        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * RotationSpeed);
        //if (_rigidbody.velocity.z < _maxSpeed)
        //{
        //_rigidbody.AddForce(Time.deltaTime * _speed * -direction, ForceMode.VelocityChange);
        //}
        //}
    }
}
