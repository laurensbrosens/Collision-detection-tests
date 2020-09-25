using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Hero
    {
        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public Physics PlayerPhysics = new Physics();
        
        public Rectangle CollisionRectangle { get; set; }
        public Hero(Vector2 spawnCoordinates) //Constructor met spawnpositie
        {
            Position = spawnCoordinates;
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 40, 40);
        }
        public Hero() //Constructor zonder argumenten met spawn linksboven
        {
            Position = new Vector2(10,10);
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 40, 40);
        }
        /*
        public void Movement()
        {
            float PositionX = PlayerInput.Inputs();
            Position += new Vector2(PositionX, 0);
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 40, 40);
        }*/
    }
}
