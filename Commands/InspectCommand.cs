using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class InspectCommand : Command
    {
        public InspectCommand() : base()
        {
            this.Name = "inspect";
        }

        override
        public bool Execute(Player player)
        {
            string inspect = "";
            if (QWords.Count == 0)
            {
                player.OutputMessage("\nInspect What?");
                
            }
            else
            {
                while (QWords.Count > 0)
                {
                    inspect += QWords.Dequeue() + " ";
                }
                inspect = inspect.TrimEnd();
                player.Inspect(inspect);
            }
            return false;
        }
    }
}
