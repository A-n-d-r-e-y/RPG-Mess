using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Components
{
    public class DirectionalGun : BaseGun
    {
        protected override void Fire(Vector3 targetVector)
        {
            var mousePositionInWorldPoint = new Vector3(targetVector.x, targetVector.y, 0);

            //Debug.Log(mousePositionInWorldPoint);

            var bullet = UnityEngine.Object.Instantiate(
                projectile,
                transform.position,
                Quaternion.identity) as BaseProjectile;

            bullet.Launch(mousePositionInWorldPoint, () => UnityEngine.Object.Destroy(bullet.gameObject));
        }

        private void Start()
        {
            inputReceiver.ArrowInputReceived += (s, e) => Fire(e.Vector3);
        }
    }
}
