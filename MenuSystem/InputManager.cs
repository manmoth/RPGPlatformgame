using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class InputManager
    {
        KeyboardState ksbefore;
        KeyboardState ksafter;
        GamePadState gsbefore;
        GamePadState gsafter;

        PlayerIndex mainIndex = PlayerIndex.One;
        public PlayerIndex MainIndex
        {
            get { return mainIndex; }
            set { mainIndex = value; }
        }
        public KeyboardState KeyStateBefore
        {
            get { return ksbefore; }
            set { ksbefore = value; }
        }
        public KeyboardState KeyStateAfter
        {
            get { return ksafter; }
            set { ksafter = value; }
        }
        public GamePadState GamePadBefore
        {
            get { return gsbefore; }
            set { gsbefore = value; }
        }
        public GamePadState GamePadAfter
        {
            get { return gsafter; }
            set { gsafter = value; }
        }
    }
}
