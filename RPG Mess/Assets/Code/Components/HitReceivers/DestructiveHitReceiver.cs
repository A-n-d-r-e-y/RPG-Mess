using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Components.HitReceivers
{
    class DestructiveHitReceiver : BaseHitReceiver
    {
        public override void ReceiveHit()
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }
}
