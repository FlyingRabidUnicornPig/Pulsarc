﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsarc.Beatmaps
{
    class Beatmap
    {
        public string FormatVersion { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Mapper { get; set; }
        public string Version { get; set; }
        public string Audio { get; set; }

        public List<SpeedVariation> speedVariations;
        public List<TimingPoint> timingPoints;
        public List<Arc> arcs;

        public Beatmap()
        {
            arcs = new List<Arc>();
            timingPoints = new List<TimingPoint>();
            speedVariations = new List<SpeedVariation>();
        }
    }
}