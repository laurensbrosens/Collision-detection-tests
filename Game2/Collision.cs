using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game2
{
    class Collision
    {
        static public void Handler(Hero hero, Obstacle obstacle)
        {
            if (Check(hero, obstacle))
            {

            }
        }
        static private bool Check(Hero hero, Obstacle obstacle)
        {
            if (hero.CollisionRectangle.Intersects(obstacle.CollisionRectangle))
            {
                Debug.WriteLine("Hit");
                return true;
            }
            return false;
        }
        static private void Fix()
        {

        }
    }
}
