using UnityEngine;
using System.Collections;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField]
    protected SpawnObject prefabToSpawn;
    [SerializeField]
    protected int maxCount = 1;

    private int counter = 0;

    protected virtual void Spawn()
    {
        if (counter < maxCount)
        {
            var instance = UnityEngine.GameObject.Instantiate(
            prefabToSpawn,
            transform.position,
            Quaternion.identity) as SpawnObject;

            instance.OnSpawnObjectDestroy += (s, e) => --counter;

            instance.transform.SetParent(this.gameObject.transform);
            ++counter;
        }
    }

}
