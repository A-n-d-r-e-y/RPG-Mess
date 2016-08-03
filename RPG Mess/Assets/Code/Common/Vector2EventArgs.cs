using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common
{
    public class Vector2EventArgs : EventArgs
    {
        public Vector2EventArgs(Vector2 current)
        {
            this.Current = current;
        }

        public Vector2 Current { get; private set; }
    }
}
