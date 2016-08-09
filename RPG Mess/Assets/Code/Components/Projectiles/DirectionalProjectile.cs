using Assets.Code.Common.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.Projectiles
{
    public class DirectionalProjectile : BaseProjectile
    {
        public override void Launch(Vector3 direction, Vector3 speed, Action callback)
        {

            StartCoroutine(MovingTowards(direction, 0.2f, speed, callback));

        }

        IEnumerator MovingTowards(Vector3 direction, float step, Vector3 speed, Action callback)
        {
            float distance = 10f;

            do
            {
                distance -= step;
                transform.Translate((direction + speed) * step);
                yield return new WaitForFixedUpdate();

            } while (distance > 0.2);

            if (callback != null) callback();
        }
    }
}
