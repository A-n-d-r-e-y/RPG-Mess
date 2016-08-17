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
        [SerializeField]
        private float distance = 10f;
        [SerializeField]
        private float projectileSpeed = 1;

        public override void Launch(Vector3 direction, Action callback)
        {
            float step = projectileSpeed;
            // we should rotate the lazer sprite along shot direction
            float angle = Vector3.Angle(direction, Vector3.right);
            // since angle is non reflex we should invert angle if y is negative
            angle = Mathf.Sign(direction.y) * angle;
            transform.Rotate(Vector3.forward, angle);

            // AND we should rotate the direction itself, but vice versa
            direction = Quaternion.Euler(0, 0, -angle) * direction;
            //StartCoroutine(MovingTowards(direction, step, callback));

            this.direction = direction;
            this.step = step;
            this.callback = callback;
            launched = true;

        }

        Vector3 direction;
        float step;
        Action callback;
        bool launched = false;

        void Update()
        {
            if (!launched) return;

            float localStep = step * Time.deltaTime;

            if (distance >= localStep)
            {
                distance -= localStep;
                //TODO -> speed addition is wrong. it deflects direction
                transform.Translate(direction * localStep);

            }
            else if (callback != null) callback();
        }

        //IEnumerator MovingTowards(Vector3 direction, float step, Action callback)
        //{
        //    do
        //    {
        //        distance -= step;
        //        //TODO -> speed addition is wrong. it deflects direction
        //        transform.Translate(direction * step);
        //        yield return new WaitForFixedUpdate();

        //    } while (distance >= step);

        //    if (callback != null) callback();
        //}
    }
}
