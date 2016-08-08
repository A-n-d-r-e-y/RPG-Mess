using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components
{
    public abstract class BaseProjectile : MonoBehaviour
    {
        public abstract void Launch(Vector3 destinationPoint, Action callback);
    }
}
