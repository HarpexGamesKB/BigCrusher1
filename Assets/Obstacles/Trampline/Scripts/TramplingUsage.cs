using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TramplingUsage : MonoBehaviour
{
    [SerializeField] private Rigidbody _physicalBody;

    private void Awake()
    {
        if (_physicalBody == null)
        {
            _physicalBody = GetComponent<Rigidbody>();
        }
    }

    private void Jump(GameObject go)
    {
        bool isCollidedGoHasTramplingLayerMask = true; // or false; 

        if (isCollidedGoHasTramplingLayerMask)
        {
            if (go.TryGetComponent(out Trampling trampling))
            {
                _physicalBody.AddForce(trampling.direction.normalized * trampling.power);
            }
        }
    }
}