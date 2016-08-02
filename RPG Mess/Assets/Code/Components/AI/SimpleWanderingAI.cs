using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.AI
{
    //[RequireComponent(typeof(MovingController))]
    public class SimpleWanderingAI : MonoBehaviour
    {
        // private variables
        private MovingController movingController;
        double remainingTime = 0;
        DateTime timeStamp;
        Vector2 currentVector;
        bool hit = false;

        // UI variables
        [SerializeField]
        float mean = 0.7f;
        [SerializeField]
        float dev = 0.3f;

        void Awake()
        {
            movingController = this.GetComponent<MovingController>();
        }

        void Start()
        {

        }

        void Update()
        {
            if (movingController == null) return;

            if (remainingTime <= 0 || hit)
            {
                remainingTime = (mean + UnityEngine.Random.Range(-dev, dev)) * 1000;

                float dX = UnityEngine.Random.Range(-1, 2);
                float dY = UnityEngine.Random.Range(-1, 2);

                currentVector = new Vector2(dX, dY);
                timeStamp = DateTime.Now;
                if (hit) hit = false;
            }
            else
            {
                DateTime now = DateTime.Now;
                remainingTime -= (now - timeStamp).TotalMilliseconds;
                timeStamp = now;
            }

            movingController.Move(currentVector);
        }
    }
}