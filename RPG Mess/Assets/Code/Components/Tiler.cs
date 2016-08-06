using UnityEngine;
using System.Collections;

namespace Assets.Code.Components
{
    public class Tiler : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] prefabTiles;

        [SerializeField]
        private int horizontalTilesCount = 20;

        [SerializeField]
        private int verticalTilesCount = 20;

        // Use this for initialization
        void Start()
        {
            if (prefabTiles.Length == 0) return;

            int
                x0 = -horizontalTilesCount / 2,
                y0 = -verticalTilesCount / 2,
                x = x0,
                y = y0;

            while (x < horizontalTilesCount)
            {
                while (y < verticalTilesCount)
                {
                    var prefab = prefabTiles[Random.Range(0, prefabTiles.Length - 1)];

                    var instance = UnityEngine.Object.Instantiate(prefab, new Vector2(x, y++), Quaternion.identity) as GameObject;

                    //instance.name = "hello";
                    instance.transform.SetParent(this.transform, false);
                }

                y = y0;
                ++x;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}