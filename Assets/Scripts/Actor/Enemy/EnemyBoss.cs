using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoss : Actor, IObserver
{
    private GameObject _player;
    private Actor target;
    [SerializeField] private int health = 100;
    private int currentHealth = 100;
    [SerializeField] private EnemyRangeStats _enemyRangeStats;
    private bool shotReady = true;
    private bool targetLocked = true;
    [SerializeField] private List<GameObject> bulletSpawnPoints;

    public int Health { get => health; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public List<GameObject> BulletSpawnPoints { get => bulletSpawnPoints; }

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
        Debug.Log("Boss Health:" + currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void Shoot()
    {
        int rand = Random.Range(0, bulletSpawnPoints.Count);
        Transform _bullet = Instantiate(_enemyRangeStats.Bullet.transform, bulletSpawnPoints[rand].transform.position, Quaternion.identity);
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
