using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRange : Actor, IObserver
{
    private GameObject _player;
    private Actor target;
    [SerializeField] private int health = 100;
    private int currentHealth = 100;
    [SerializeField] private EnemyRangeStats _enemyRangeStats;
    private bool shotReady = true;
    private bool targetLocked = true;
    [SerializeField] private GameObject bulletSpawnPoint;

    public int Health { get => health; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public GameObject BulletSpawnPoint { get => bulletSpawnPoint; }

    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        target = _player.gameObject.GetComponent<Actor>();
        currentHealth = health;
    }

    protected override void Update()
    {
        if (targetLocked)
        {
            transform.LookAt(target.transform);
            transform.Rotate(_enemyRangeStats.Offset, 0, 0);
            if (shotReady)
            {
                Shoot();
            }
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        Transform _bullet = Instantiate(_enemyRangeStats.Bullet.transform,bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(_enemyRangeStats.FireTimer);
        shotReady = true;
    }

    public void OnNotify(ISubject subject, IEvent ev)
    {
        
    }
}
