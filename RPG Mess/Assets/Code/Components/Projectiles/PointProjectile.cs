using Assets.Code.Common.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.Projectiles
{
    public class PointProjectile : BaseProjectile
    {
        public override void Launch(Vector3 destinationPoint, Vector3 speed, Action callback)
        {

            StartCoroutine(MovingTowards(destinationPoint, 0.1f, speed, callback));

        }

        IEnumerator MovingTowards(Vector3 destinationPoint, float step, Vector3 speed, Action callback)
        {
            Vector3 direction;
            float distance = 0.0f;

            do
            {
                direction = destinationPoint - transform.position;
                distance = direction.magnitude;
                transform.Translate((direction.normalized + speed) * step);
                yield return new WaitForFixedUpdate();

            } while (distance > 0.2);

            if (callback != null) callback();
        }
    }
}
