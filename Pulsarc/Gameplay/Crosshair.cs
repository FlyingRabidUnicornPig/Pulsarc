﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pulsarc.Skinning;

namespace Pulsarc.Gameplay
{
    class Crosshair : Drawable
    {
        public Crosshair() : base(Skin.crosshair)
        {
            Vector2 screen = Pulsarc.getDimensions();
            float radius = 200f / 1920f * screen.X;


            origin.X = (screen.X / 2) + ((texture.Width - screen.X) / 2);
            origin.Y = (screen.Y / 2) + ((texture.Height - screen.Y) / 2);
            position.X = screen.X / 2;
            position.Y = screen.Y / 2;
            Resize(radius);

            rotation = (float)(45 * (Math.PI / 180));
        }
    }
}