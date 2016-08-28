using UnityEngine;
using System.Collections;

public class GameRestarter : MonoBehaviour {

	public void RestartTheGame()
    {
        var hitCollector = GetComponentInParent<HitInfoCollector>();
        if (hitCollector != null)
        {
            hitCollector.Reset();
        }

        // destroy all enemies
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            DestroyObject(obj);
        }
    }
}
