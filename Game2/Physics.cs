using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Physics
    {
        public float groundResistance { get; set; } = 0.15f; //Weerstand op de grond
        public float airResistance { get; set; } = 0.015f; //Weerstand in de lucht
        public float inputAcceleration { get; set; } = 100f; //Acceleratie door input
        //public float AccelerationX { get; set; } = 0f; //Horizontale acceleratie
        public float Gravity { get; set; } = 9.8f; //Acceleratie door zwaartekracht
        public float jumpingSpeed { get; set; } = 10f; //Snelheid bij springen
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal
        public float VelocityY { get; set; } = 0; //Snelheid verticaal

        public float horizontalInput = 0f; //De input van de speler horizontaal
        public float verticalInput = 0f; //De input van de speler verticaal

        private Input PlayerInput = new Input(); //Object initialiseren om input keyboard raad te plegen
        public Vector2 Movement(GameTime gameTime, State state)
        {
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 playerInput = PlayerInput.Inputs();
            horizontalInput = playerInput.X;
            verticalInput = playerInput.Y;
            if (state.SlidingLeft && horizontalInput > 0)
            {
                horizontalInput = 0;
            }
            else if (state.SlidingRight && horizontalInput < 0)
            {
                horizontalInput = 0;
            }


            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX; //Berekening van horizontale snelheid, snelheidx = acceleratie * input - grondweerstand * snelheidx
            if (verticalInput != 0 && state.Grounded == true) //Als springen wordt ingeduwd en player staat op de grond kan hij springen
            {
                VelocityY = -jumpingSpeed;
            }
            else
            {
                VelocityY += VelocityY * deltaT + 50f * Gravity * deltaT * deltaT - airResistance * VelocityY; //Berekening van verticale snelheid met zwaartekracht
            }
            return new Vector2(VelocityX * deltaT, VelocityY);
        }
    }
}
