using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Obstacle
    {
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Obstacle(int positionX, int positionY, int width, int height)
        {
            Position = new Vector2(positionX, positionY);
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), width, height);
        }

    }
}
