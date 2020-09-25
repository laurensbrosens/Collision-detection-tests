using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Input
    {
        public float Inputs()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.A))
            {
                return -1f;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                return 1f;
            }
            return 0f;
        }
    }
}
