using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Input
    {
        public Vector2 Inputs()
        {
            float displacmentX = 0f;
            float displacmentY = 0f;
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.A))
            {
                displacmentX += - 1f;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                displacmentX += 1f;
            }
            if (stateKey.IsKeyDown(Keys.Space))
            {
                displacmentY += 1f;
            }
            return new Vector2((int)displacmentX, (int)displacmentY);
        }
    }
}
