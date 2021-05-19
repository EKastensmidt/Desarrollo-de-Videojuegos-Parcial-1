using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Actor
{
    [SerializeField] private PlayerStats _playerStats;
    protected override void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            EnemyMelee enemy = other.gameObject.GetComponent<EnemyMelee>();
            enemy.EnemyTakeDamage(_playerStats.Damage);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 9)
        {
            EnemyRange enemy = other.gameObject.GetComponent<EnemyRange>();
            enemy.EnemyTakeDamage(_playerStats.Damage);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 10)
        {
            EnemyBoss enemy = other.gameObject.GetComponent<EnemyBoss>();
            enemy.EnemyTakeDamage(_playerStats.Damage);
            Destroy(gameObject);
        }
    }
}
