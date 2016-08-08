using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Common
{
    public class MouseClickEventArgs : EventArgs
    {
        public enum MouseButton
        {
            LeftMouseButton,
            RightMouseButton,
            MiddleMouseButton,
        }

        public MouseClickEventArgs(MouseButton mouseButton)
        {
            this.PressedMouseButton = mouseButton;
        }

        public MouseButton PressedMouseButton { get; private set; }
    }
}
