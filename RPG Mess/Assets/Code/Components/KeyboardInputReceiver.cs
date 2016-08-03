using UnityEngine;
using System.Collections;
using Assets.Code.Components;
using System;
using Assets.Code.Common;

namespace Assets.Code.Components
{
    public class KeyboardInputReceiver : BaseInputReceiver
    {
        public override event EventHandler<Vector2EventArgs> InputReceived;

        // Update is called once per frame
        public override void Update()
        {
            float dX = Input.GetAxis("Horizontal");
            float dY = Input.GetAxis("Vertical");

            var dV = new Vector2(dX, dY);

            InputReceived(this, new Vector2EventArgs(dV));
        }
    }
}