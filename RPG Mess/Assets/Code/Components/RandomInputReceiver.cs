using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Components
{
    public class RandomInputReceiver : BaseInputReceiver
    {
        // private variables
        double remainingTime = 0;
        DateTime timeStamp;
        Vector2 currentVector;
        bool hit = false;

        // UI variables
        [SerializeField]
        float mean = 0.7f;
        [SerializeField]
        float dev = 0.3f;

        public override event EventHandler<Vector2EventArgs> MoveInputReceived;
        public override event EventHandler<Vector3EventArgs> FireInputReceived;
        public override event EventHandler<Vector3EventArgs> ArrowInputReceived;

        public override void Update()
        {
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

            MoveInputReceived(this, new Vector2EventArgs(currentVector));
        }
    }
}