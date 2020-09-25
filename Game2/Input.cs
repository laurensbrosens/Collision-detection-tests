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
            float displacment = 0f;
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.A))
            {
                displacment += - 1f;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                displacment += 1f;
            }
            return displacment;
        }
    }
}
