﻿using Microsoft.Xna.Framework;
using Pulsarc.Skinning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulsarc.UI
{
    class Cursor : Drawable
    {
        public Cursor() : base(Skin.assets["cursor"])
        {
            Resize(texture.Width / (texture.Width / (48 / (float) 1920 * Pulsarc.getDimensions().X)));
        }

        public void setPos(Point position)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
        }
    }
}