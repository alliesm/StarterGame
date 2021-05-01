using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class ExploreCommand : Command
    {
        public ExploreCommand() : base()
        {
            this.Name = "explore";
        }

        override
        public bool Execute(Player player)
        {
            if (QWords.Count > 0)
            {
                player.OutputMessage("\nI can't explore " + QWords);
            }
            else
            {
                player.Explore();
            }
            return false;
        }
    }
}
