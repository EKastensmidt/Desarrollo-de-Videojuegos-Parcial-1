using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Actor
{
    private PlayerInputs _playerInput;
    [SerializeField] private PlayerStats _playerStats;

    void OnEnable()
    {
        GameEvents.instance.onDamageTrigger += TakeDamage;
    }
    void OnDisable()
    {
        GameEvents.instance.onDamageTrigger -= TakeDamage;
    }

    protected override void Start()
    {
        base.Start();
        _playerInput = GetComponent<PlayerInputs>();
        _playerStats.Execute();
    }

    protected override void Update()
    {
        if (_playerInput.IsMoving) Move(_playerInput.Movement);
        if (_playerInput.IsRotating) Rotate(_playerInput.Rotation);
        if (_playerInput.IsShooting) Shoot(_playerStats.BulletEmitter, _playerStats.Bullet, _playerStats.BulletSpeed);
    }

    public void TakeDamage(int damage)
    {
        _playerStats.CurrentHealth -= damage;
        Debug.Log("My Health:" + _playerStats.CurrentHealth);
        if(_playerStats.CurrentHealth <= 0)
        {
            Die();
        }
    }
}
