using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.Projectiles
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BaseProjectile : MonoBehaviour
    {
        [SerializeField]
        protected LayerMask targetMask;

        public abstract void Launch(Vector3 destinationPoint, Action callback);
    }
}
