using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class SpawnManager : MonoBehaviour
{
    private Spawner spawner;

    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    void FixedUpdate(){

        if(spawner.isEnabled & GlobalManager.Instance.GameManager().startLevel){
            StartCoroutine(spawner.SpawnEnemies());
        }
    }
}
