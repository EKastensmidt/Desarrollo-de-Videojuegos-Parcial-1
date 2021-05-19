using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private EnemyRangeStats _enemyRangeStats;
    [SerializeField] private float bulletLifeTime = 3;
    public float BulletSpeed { get => bulletSpeed; }
    public float BulletLifeTime { get => bulletLifeTime; }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameEvents.instance.DamageTaken(_enemyRangeStats.Damage);
            Destroy(gameObject);
        }
    }
}
