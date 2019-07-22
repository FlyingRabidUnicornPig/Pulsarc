﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsarc.Utils.BeatmapConversion
{
    class IntralismBeatmap
    {
        public long configVersion;
        public string name;
        public string info;

        public List<Dictionary<string, string>> levelResources;
        public List<string> tags;

        public long handCount;
        public string moreInfoURL;

        public long speed;
        public long lives;
        public long maxLives;
        public string musicFile;
        public double musicTime;

        public string iconFile;
        public long environmentType;

        public List<Dictionary<string, string>> unlockConditions;
        public bool hidden;
        public List<Dictionary<string, string>> checkpoints;

        public List<Event> events;
    }

    class Event
    {
        public double time;
        public List<string> data;
    }
}