using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour, IEvent
{
    public int Priority => 1;

    void OnEnable()
    {
        GameEvents.instance.onDieTrigger += PlayerDeath;
    }

    void OnDisable()
    {
        GameEvents.instance.onDieTrigger -= PlayerDeath;
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
