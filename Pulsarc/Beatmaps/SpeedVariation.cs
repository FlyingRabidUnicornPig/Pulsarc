﻿using System.Globalization;

namespace Pulsarc.Beatmaps
{
    class SpeedVariation
    {
        public int time;
        public int type;
        public double intensity;

        public SpeedVariation(int time, int type, double intensity)
        {
            this.time = time;
            this.type = type;
            this.intensity = intensity;
        }

        public string toString()
        {
            return time + "," + type + "," + intensity.ToString("0.000", CultureInfo.InvariantCulture);
        }
    }
}