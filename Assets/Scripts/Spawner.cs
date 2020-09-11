using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public Object enemy;
    private float time;
    private Transform pos;


    void Start()
    {
        pos = this.transform;
        spawnTime = 1.7f;
        time = spawnTime;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Instantiate(enemy, pos);
            time = spawnTime;
        }        
    }
}
