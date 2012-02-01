using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    /// <summary>
    ///  GameControls contains some constant keymappings that makes it easier to remap the function of keys later on.
    /// </summary>
    public static class GameControls
    {
        #region Fields: Input
        /// <summary>
        ///  KeyBoard: Walk left.
        /// </summary>
        public const Keys KWalkLeft = Keys.Left;
        /// <summary>
        ///  KeyBoard: Walk right.
        /// </summary>
        public const Keys KWalkRight = Keys.Right;
        /// <summary>
        ///  KeyBoard: Jump.
        /// </summary>
        public const Keys KJump = Keys.Up;
        /// <summary>
        ///  Keyboard: Action.
        /// </summary>
        public const Keys KAction = Keys.Enter;
        /// <summary>
        ///  KeyBoard: Menu Screen.
        /// </summary>
        public const Keys KMenu = Keys.Escape;
        /// <summary>
        ///  Gamepad: Walk left.
        /// </summary>
        public const Buttons GWalkLeft = Buttons.LeftThumbstickLeft;
        /// <summary>
        ///  Gamepad: Walk right.
        /// </summary>
        public const Buttons GWalkRight = Buttons.LeftThumbstickRight;
        /// <summary>
        ///  Gamepad: Jump.
        /// </summary>
        public const Buttons GJump = Buttons.X;
        /// <summary>
        ///  Gamepad: Action.
        /// </summary>
        public const Buttons GAction = Buttons.A;
        /// <summary>
        ///  Gamepad: Menu.
        /// </summary>
        public const Buttons GMenu = Buttons.Start;
        /// <summary>
        ///  Gamepad: Menu down.
        /// </summary>
        public const Buttons GMenuDown = Buttons.LeftThumbstickDown;
        /// <summary>
        ///  Gamepad: Menu up.
        /// </summary>
        public const Buttons GMenuUp = Buttons.LeftThumbstickUp;

        #endregion
    }
}
