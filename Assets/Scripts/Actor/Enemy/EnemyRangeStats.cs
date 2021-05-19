using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyRange", menuName = "Scriptable Object/Enemy", order = 0)]
public class EnemyRangeStats : ActorStats, ICommand
{
    [SerializeField] private float offset;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireTimer;

    public float Offset { get => offset; }
    public GameObject Bullet { get => bullet; }
    public float FireTimer { get => fireTimer; }

    public void Execute()
    {
        
    }

}
