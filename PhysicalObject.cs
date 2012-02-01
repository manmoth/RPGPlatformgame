using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WindowsGame1
{
    interface PhysicalObject
    {
        List<Body> Bodies { get; set;}

        void InitializePhysics(World world);
        Vector2 GetPosition();
    }
}
