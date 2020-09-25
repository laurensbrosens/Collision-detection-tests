using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Physics
    {
        public float groundResistance { get; set; } = 0.15f; //Weerstand op de grond
        public float airResistance { get; set; } = 0.04f; //Weerstand in de lucht
        public float inputAcceleration { get; set; } = 100f; //Acceleratie door input
        //public float AccelerationX { get; set; } = 0f; //Horizontale acceleratie
        public float Gravity { get; set; } = 0.98f; //Acceleratie door zwaartekracht
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal
        public float VelocityY { get; set; } = 0; //Snelheid verticaal

        public float horizontalInput = 0f; //De input van de speler

        private Input PlayerInput = new Input(); //Object initialiseren om input keyboard raad te plegen
        public Vector2 Movement(GameTime gameTime)
        {
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            horizontalInput = PlayerInput.Inputs();
            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX;
            return new Vector2(VelocityX * deltaT, 0);
        }
    }
}
