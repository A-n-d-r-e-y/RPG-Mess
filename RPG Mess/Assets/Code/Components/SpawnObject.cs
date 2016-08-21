using UnityEngine;
using System.Collections;
using System;

public class SpawnObject : MonoBehaviour {

    public event EventHandler<EventArgs> OnSpawnObjectDestroy;

    void OnDestroy()
    {
        if (OnSpawnObjectDestroy != null) OnSpawnObjectDestroy(this, new EventArgs());
    }
}
