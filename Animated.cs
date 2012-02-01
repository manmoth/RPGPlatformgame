using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    interface Animated
    {
        int AnimationSteps{get; set;}
        int AnimationFrame { get; set; }
        int TotalFrames { get; set; }

        void AnimationStep();
        void AnimationReset();
    }
}
