using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using System;

namespace Game2
{
    class Collision
    {
        static public void Handler(Hero hero, Obstacle obstacle)
        {
            Check(hero, obstacle);
        }
        static private void Check(Hero hero, Obstacle obstacle)
        {
            if (hero.CollisionRectangle.Intersects(obstacle.CollisionRectangle))
            {
                hero.Compensation += Fix(hero, obstacle);
            }
        }
        static private Vector2 Fix(Hero hero, Obstacle obstacle)
        {
            int heroCenterX = hero.PositionOld.X;
            int heroCenterY = hero.PositionOld.Y;
            int obstacleLeft = obstacle.CollisionRectangle.Left;
            int obstacleRight = obstacle.CollisionRectangle.Right;
            int obstacleBottom = obstacle.CollisionRectangle.Bottom;
            int obstacleTop = obstacle.CollisionRectangle.Top;
            if (obstacleLeft < heroCenterX && heroCenterX < obstacleRight)
            {
                if (heroCenterY < obstacleBottom)
                {
                    return new Vector2(0, obstacleTop - hero.CollisionRectangle.Bottom); //Naar boven
                }
                else
                {
                    return new Vector2(0, obstacleBottom - hero.CollisionRectangle.Top); //Naar beneden
                }
            }
            else if (obstacleTop < heroCenterY && heroCenterY < obstacleBottom)
            {
                if (heroCenterX < obstacleLeft)
                {
                    return new Vector2(obstacleLeft - hero.CollisionRectangle.Right, 0); //Naar links

                }
                else
                {
                    return new Vector2(obstacleRight - hero.CollisionRectangle.Left, 0); //Naar rechts
                }
            }
            else if (obstacleTop > heroCenterY)
            {
                if (heroCenterX < obstacleLeft)
                {
                    int left = obstacleLeft - hero.CollisionRectangle.Right;
                    int top = obstacleTop - hero.CollisionRectangle.Bottom;
                    if (top > left)
                    {
                        return new Vector2(0, top); //Naar boven
                    }
                    else
                    {
                        return new Vector2(left, 0); //Naar links
                    }
                }
                else
                {
                    int right = obstacleRight - hero.CollisionRectangle.Left;
                    int top = obstacleTop - hero.CollisionRectangle.Bottom;
                    if (-top < right)
                    {
                        return new Vector2(0, top); //Naar boven
                    }
                    else
                    {
                        return new Vector2(right, 0); //Naar rechts
                    }
                }
            }
            else
            {
                if (heroCenterX < obstacleLeft)
                {
                    int left = obstacleLeft - hero.CollisionRectangle.Right;
                    int bottom = obstacleBottom - hero.CollisionRectangle.Top;
                    if (-left > bottom)
                    {
                        return new Vector2(0, bottom); //Naar beneden
                    }
                    else
                    {
                        return new Vector2(left, 0); //Naar links
                    }

                }
                else
                {
                    int right = obstacleRight - hero.CollisionRectangle.Left;
                    int bottom = obstacleBottom - hero.CollisionRectangle.Top;
                    if (right > bottom)
                    {
                        return new Vector2(0, bottom); //Naar beneden
                    }
                    else
                    {
                        return new Vector2(right, 0); //Naar rechts
                    }
                }
            }
        }
    }
}
