using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Object/Player", order = 0)]
public class PlayerStats : ActorStats, ICommand
{
    private GameObject bulletEmitter;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] private int health = 100;
    private int currentHealth = 100;

    public int Health { get => health; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public GameObject Bullet { get => bullet; }
    public float BulletSpeed { get => bulletSpeed; }
    public GameObject BulletEmitter { get => bulletEmitter; }

    public void Execute()
    {
        CurrentHealth = Health;
        bulletEmitter = GameObject.Find("Emitter");
    }
}
