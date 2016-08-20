using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour
{
    private DateTime time_save = DateTime.Now;

    [SerializeField]
    GameObject prefabToSpawn;
    [SerializeField]
    private double spawnRate = 5;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        double delay_ms = 1000 / spawnRate;

        if (time_save.AddMilliseconds(delay_ms) <= DateTime.Now)
        {
            UnityEngine.Object.Instantiate(
                prefabToSpawn,
                transform.position,
                Quaternion.identity);

            time_save = DateTime.Now;
        }
    }
}
