using Assets.Code.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components
{
    [RequireComponent(typeof(BaseInputReceiver))]
    public abstract class BaseGun : MonoBehaviour
    {
        [SerializeField]
        protected BaseProjectile projectile;

        protected BaseInputReceiver inputReceiver;

        protected abstract void Fire(Vector3 direction);

        void Awake()
        {
            inputReceiver = this.GetComponent<BaseInputReceiver>();
        }
    }
}
