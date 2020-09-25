using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Physics
    {
        public float groundResistance { get; set; } = 0.4f; //Weerstand op de grond
        public float airResistance { get; set; } = 0.04f; //Weerstand in de lucht
        public float Acceleration { get; set; } = 10f; //Acceleratie door input
        public float Gravity { get; set; } = 0.98f; //Acceleratie door zwaartekracht

        public Vector2 Velocity { get; set; } = new Vector2(0, 0);
    }
}
