using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public interface ILivingCreature
    {
       int CurrentHitPoints { get; set; }
       int MaximumHitPoints { get; set; }
        
    }
}
