using UnityEngine;
using System.Collections;

public class GameRestarter : MonoBehaviour {

	public void RestartTheGame()
    {
        // destroy all enemies
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            DestroyObject(obj);
        }
    }
}
