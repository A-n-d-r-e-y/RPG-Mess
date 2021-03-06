﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Common;
using UnityEngine;
using Assets.Code.Components.Projectiles;

namespace Assets.Code.Components.Guns
{
    public class DirectionalGun : BaseGun
    {
        private DateTime time_save = DateTime.Now;
        [SerializeField]
        private double firingRate = 5;

        protected override void Fire(Vector3 targetVector)
        {
            double delay_ms = 1000 / firingRate;
            if (time_save.AddMilliseconds(delay_ms) <= DateTime.Now)
            {
                var mousePositionInWorldPoint = new Vector3(targetVector.x, targetVector.y, 0);

                //Debug.Log(mousePositionInWorldPoint);

                var bullet = UnityEngine.Object.Instantiate(
                    projectile,
                    transform.position,
                    Quaternion.identity) as BaseProjectile;

                bullet.transform.SetParent(this.transform);

                bullet.Launch(mousePositionInWorldPoint, () => UnityEngine.Object.Destroy(bullet.gameObject));

                time_save = DateTime.Now;
            }
        }

        private void Start()
        {
            inputReceiver.ArrowInputReceived += (s, e) => Fire(e.Vector3);
        }
    }
}
