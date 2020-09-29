using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class State
    {
        public bool Grounded { get; set; }
        public bool SlidingLeft { get; set; }
        public bool SlidingRight { get; set; }
        public bool BumpHead { get; set; }
        public void StateCheck(Hero hero, Vector2 Compensation)
        {
            if (Compensation.X < 0)
            {
                hero.PlayerState.SlidingLeft = true;
                hero.PlayerPhysics.VelocityX = 0;
            }
            else
            {
                hero.PlayerState.SlidingLeft = false;
            }
            if (Compensation.X > 0)
            {
                hero.PlayerState.SlidingRight = true;
                hero.PlayerPhysics.VelocityX = 0;
            }
            else
            {
                hero.PlayerState.SlidingRight = false;
            }
            if (Compensation.Y < 0)
            {
                hero.PlayerPhysics.VelocityY = 0;
                hero.PlayerState.Grounded = true;
                hero.PlayerPhysics.Gravity = 0;
            }
            else
            {
                hero.PlayerState.Grounded = false;
                hero.PlayerPhysics.Gravity = 9.8f;
            }
            if (Compensation.Y > 0)
            {
                hero.PlayerPhysics.VelocityY = 0;
                hero.PlayerState.BumpHead = true;
            }
            else
            {
                hero.PlayerState.BumpHead = false;
            }
        }
    }
}
