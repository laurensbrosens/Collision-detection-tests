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
        public Obstacle()
        {
            Position = new Vector2(-10, 300);
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 1500, 200);
        }

    }
}
