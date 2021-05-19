using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory 
{
    //GameObject Prefab { get; set; }
    GameObject Create(GameObject product);
}
