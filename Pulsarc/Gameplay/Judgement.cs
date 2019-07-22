﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsarc.Gameplay
{
    static class Judgement
    {
        static public List<JudgementValue> judgements = new List<JudgementValue>()
        {
            new JudgementValue(1,       16,     320),       // MAX
            new JudgementValue(1,       25,     300),       // Perfect
            new JudgementValue(2/3,     40,     200),       // Great
            new JudgementValue(1/3,     60,     100),       // Good
            new JudgementValue(1/6,     100,    50),        // Bad
            new JudgementValue(0,       130,    0),         // Miss
        };
    

        static public KeyValuePair<double, int> getErrorJudgement(int error)
        {
            KeyValuePair<double, int> result = new KeyValuePair<double, int>(-1, -1);
            if (error < judgements.Last().acc)
            {
                bool notJudged = true;

                for (int i = 0; i < judgements.Count && notJudged; i++)
                {
                    JudgementValue judgement = judgements[i];

                    if (error < judgement.acc)
                    {
                        result = new KeyValuePair<double, int>(judgement.acc, judgement.judge);
                        notJudged = false;
                    }
                }

                if(notJudged)
                {
                    result = new KeyValuePair<double, int>(0, 0);
                }
            }

            return result;
        }

        static public JudgementValue getMiss()
        {
            return judgements.Last();
        }
    }

    class JudgementValue {

        public double acc;
        public int judge;
        public long score;

        public JudgementValue(double acc, int judge, long score)
        {
            this.acc = acc;
            this.judge = judge;
            this.score = score;
        }
    }
}