using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private float _bounceMultiplier = 1;

    public float BounceMultiplier { get => _bounceMultiplier; }
}
