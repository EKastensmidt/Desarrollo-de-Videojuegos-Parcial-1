using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMelee : Actor, IObserver
{
    private GameObject _player;
    private Actor target;
    [SerializeField] private int health = 100;
    private int currentHealth = 100;
    public int Health { get => health; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        target  = _player.gameObject.GetComponent<Actor>();
        currentHealth = health;
    }

    protected override void Update()
    {
        transform.Translate((target.transform.position - transform.position).normalized * Stats.Speed * Time.deltaTime);
    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameEvents.instance.DamageTaken(Stats.Damage);
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

    public void OnNotify(ISubject subject, IEvent ev)
    {

    }
    
}
