using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components
{
    public class DirectionalProjectile : BaseProjectile
    {
        public override void Launch(Vector3 direction, Action callback)
        {

            StartCoroutine(MovingTowards(direction, 0.1f, callback));

        }

        IEnumerator MovingTowards(Vector3 direction, float step, Action callback)
        {
            float distance = 10f;

            do
            {
                distance -= step;
                transform.Translate(direction * step);
                yield return new WaitForFixedUpdate();

            } while (distance > 0.2);

            if (callback != null) callback();
        }
    }
}
