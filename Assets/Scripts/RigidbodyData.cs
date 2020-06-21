using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RigidbodyData : ScriptableObject
{
    [SerializeField] float mass;
    [SerializeField] float linearDrag;
    [SerializeField] float angularDrag;

    public float Mass { get => mass; }
    public float LinearDrag { get => linearDrag; }
    public float AngularDrag { get => angularDrag; }
}
