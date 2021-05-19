using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action<int> onDamageTrigger;
    public void DamageTaken(int damage)
    {
        if (onDamageTrigger != null) onDamageTrigger(damage);
    }

    public event Action onDieTrigger;
    public void Death()
    {
        if (onDieTrigger != null) onDieTrigger();
    }

    public event Action<int> onSpawnEnemies;
    public void Spawn(int id)
    {
        if (onSpawnEnemies != null) onSpawnEnemies(id);
    }
}
