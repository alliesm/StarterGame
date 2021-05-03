using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardGold { get; set; }

        public Quest(int id, string name, string description, int rewardGold)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardGold = rewardGold;
        }
    }
}
