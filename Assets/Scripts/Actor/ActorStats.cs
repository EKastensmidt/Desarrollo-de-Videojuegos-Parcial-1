using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor", menuName = "Scriptable Object/Actor", order = 0)]
public class ActorStats : ScriptableObject
{
    [SerializeField] private float speed = 5;
    [SerializeField] private int damage = 10;
    [SerializeField] private float rotationSpeed = 5;

    public float Speed { get => speed;  }
    public int Damage { get => damage; }
    public float RotationSpeed { get => rotationSpeed; }
}
