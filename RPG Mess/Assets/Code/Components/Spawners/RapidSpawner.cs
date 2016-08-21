using UnityEngine;
using System.Collections;
using System;

public class RapidSpawner : BaseSpawner
{
    [SerializeField]
    private double spawnRate = 5;

    private DateTime time_save = DateTime.Now;

    // Update is called once per frame
    void Update()
    {
        double delay_ms = 1000 / spawnRate;

        if (time_save.AddMilliseconds(delay_ms) <= DateTime.Now)
        {
            Spawn();
            time_save = DateTime.Now;
        }
    }
}
