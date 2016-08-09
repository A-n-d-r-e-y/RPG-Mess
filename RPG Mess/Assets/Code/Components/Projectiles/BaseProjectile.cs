using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.Projectiles
{
    public abstract class BaseProjectile : MonoBehaviour
    {
        public abstract void Launch(Vector3 destinationPoint, Vector3 speed, Action callback);
    }
}
