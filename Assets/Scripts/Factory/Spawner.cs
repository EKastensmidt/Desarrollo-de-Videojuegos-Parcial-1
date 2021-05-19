using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner :MonoBehaviour, IFactory
{
    public GameObject Create(GameObject product)
    {
        return GameObject.Instantiate(product as GameObject);
    }
}
