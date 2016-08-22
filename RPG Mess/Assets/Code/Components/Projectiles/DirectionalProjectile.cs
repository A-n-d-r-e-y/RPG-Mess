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
        private float projectileSpeed = 10;

        private Vector3 direction;
        private Action callback;
        private bool launched = false;
        private float remainingDistance;

        public override void Launch(Vector3 direction, Action callback)
        {
            // we should rotate the lazer sprite along shot direction
            float angle = Vector3.Angle(direction, Vector3.right);
            // since angle is non reflex we should invert angle if y is negative
            angle = Mathf.Sign(direction.y) * angle;
            transform.Rotate(Vector3.forward, angle);

            // AND we should rotate the direction itself, but vice versa
            direction = Quaternion.Euler(0, 0, -angle) * direction;

            this.direction = direction;
            this.callback = callback;
            this.remainingDistance = distance;
            this.launched = true;

        }

        void Update()
        {
            if (!launched) return;

            float step = projectileSpeed * Time.deltaTime;

            if (remainingDistance >= step)
            {
                var hitCaster = GetComponent<HitCaster>();
                if (hitCaster != null)
                {
                    if (hitCaster.CastHitIfNeeded(direction))
                    {
                        var hitCollector = GetComponentInParent<HitInfoCollector>();
                        if (hitCollector != null)
                        {
                            hitCollector.CollectHit();
                        }

                        EndOfThePath();
                        return;
                    }
                }

                remainingDistance -= step;
                transform.Translate(direction * step);

            }
            else
            {
                EndOfThePath();
            }
        }

        private void EndOfThePath()
        {
            launched = false;
            if (callback != null) callback();
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
