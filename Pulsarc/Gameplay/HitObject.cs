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
    class HitObject : Drawable
    {
        public int time;

        double angle;
        double radius;

        double distanceToCrosshair;

        public HitObject(int time, int angle, int keys, double baseSpeed) : base(Skin.arcs)
        {
            this.time = time;
            this.angle = angle;

            Vector2 screen = Pulsarc.getDimensions();
            radius = (200f / 1920f) * screen.X;

            origin.X = (screen.X / 2) + ((texture.Width - screen.X) / 2);
            origin.Y = (screen.Y / 2) + ((texture.Height - screen.Y) / 2);

            position.X = screen.X / 2;
            position.Y = screen.Y / 2;

            drawnPart.Width = texture.Width / 2;
            drawnPart.Height = texture.Height / 2;

            switch(angle)
            {
                case 0:
                    drawnPart.Width = texture.Width / 2;
                    drawnPart.Height = texture.Height / 2;
                    drawnPart.X = texture.Width / 2;
                    origin.X -= texture.Width / 2;
                    break;
                case 270:
                    drawnPart.Width = texture.Width / 2;
                    drawnPart.Height = texture.Height / 2;
                    break;
                case 180:
                    drawnPart.Width = texture.Width / 2;
                    drawnPart.Height = texture.Height / 2;
                    drawnPart.Y = texture.Height / 2;
                    origin.Y -= texture.Height / 2;
                    break;
                case 90:
                    drawnPart.Width = texture.Width / 2;
                    drawnPart.Height = texture.Height / 2;
                    drawnPart.X = texture.Width / 2;
                    drawnPart.Y = texture.Height / 2;
                    origin.X -= texture.Width / 2;
                    origin.Y -= texture.Height / 2;
                    break;
            }

            rotation = (float) (45 * (Math.PI / 180));
        }
        

        public void recalcPos(int currentTime, double speed, int crosshairRadius)
        {
            Vector2 screen = Pulsarc.getDimensions();

            distanceToCrosshair = getDistanceToCrosshair(currentTime, speed);

            Resize(getSizeFromDistanceToCrosshair(crosshairRadius));
        }

        public int getSizeFromDistanceToCrosshair(int crosshairRadius)
        {
            return (int) (((crosshairRadius / 1920f) * Pulsarc.getDimensions().X) + distanceToCrosshair);
        }

        public double getDistanceToCrosshair(int currentTime, double speed)
        {
            var distanceT = time - currentTime;
            return Math.Pow(distanceT + 562.3413, 4) / 1e9 * speed - 100;
        }

        public bool IsSeen()
        {
            // true for testing even with bad performance
            return true || texture.Width < Pulsarc.getDimensions().X * 2;
        }
    }
}