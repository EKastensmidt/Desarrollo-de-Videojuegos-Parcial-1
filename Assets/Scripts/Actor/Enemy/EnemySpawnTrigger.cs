using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField] private int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.Spawn(id);
        Destroy(gameObject);
    }
}
