using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private GameObject _spawnedObject;

    public void Spawn(Vector3 position)
    {
        _spawnedObject = Instantiate(_prefab, position, Quaternion.identity);
    }

    public void Destroy()
    {
        if(_spawnedObject == null)
            return;

        Destroy(_spawnedObject);
    }
}
