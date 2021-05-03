using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface LivingCreature
    {
        int CurrentHitPoints { get; set; }
        int MaximumHitPoints { get; set; }
        /*public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }*/
    }
}
