using Assets.Code.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components
{
    public abstract class BaseInputReceiver : MonoBehaviour
    {
        public abstract event EventHandler<Vector2EventArgs> InputReceived;

        public abstract void Update();
    }
}
