using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (player.transform.position.y < -50 || Input.GetKeyDown(KeyCode.T))
        {
            GameEvents.instance.Death();
        }

    }
}
